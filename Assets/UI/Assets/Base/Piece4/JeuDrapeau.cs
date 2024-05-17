using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe pour g�rer le jeu de reconnaissance de drapeaux.
/// </summary>
public class JeuDrapeau : MonoBehaviour
{
    private float chronometre = 5.0f; // Temps par question
    public Image drapeauImage; // Image pour afficher le drapeau
    public List<Sprite> listeDrapeaux; // Liste des sprites de drapeaux
    public Button[] boutonsOptions; // Boutons pour afficher les noms des pays
    public Text texteChronometre; // Texte pour afficher le chronom�tre
    public Text texteScore; // Texte pour afficher le score
    public Text finPartie; // Texte pour afficher le message de fin de partie
    public Button quitter; // Bouton pour quitter le jeu
    private int bonIndex; // Index de la bonne r�ponse de nom du drapeau affich�
    private int score = 0; // Score du joueur
    private bool enTrainDeJouer = true; // Indicateur de l'�tat du jeu

    /// <summary>
    /// M�thode appel�e au d�marrage du jeu.
    /// Initialise le score et affiche le premier drapeau.
    /// </summary>
    void Start()
    {
        texteScore.text = "Score: " + score;
        ProchainDrapeau();
    }

    /// <summary>
    /// M�thode appel�e � chaque frame.
    /// G�re le chronom�tre et le passage au drapeau suivant.
    /// </summary>
    void Update()
    {
        if (!enTrainDeJouer) return;

        chronometre -= Time.deltaTime;
        texteChronometre.text = Mathf.Round(chronometre).ToString();

        // Si 5 secondes ont �t� �coul�es, on g�n�re un nouveau drapeau.
        if (chronometre <= 0)
        {
            ProchainDrapeau();
        }
    }

    /// <summary>
    /// S�lectionne et affiche un nouveau drapeau, puis r�initialise le chronom�tre.
    /// </summary>
    private void ProchainDrapeau()
    {
        // V�rifie si le joueur a atteint le score n�cessaire pour gagner
        if (score >= 25)
        {
            FinirJeu(); // Appelle la m�thode pour terminer le jeu
            return;
        }

        // R�initialise le chronom�tre � 5 secondes
        chronometre = 5.0f;

        // S�lectionne un index al�atoire pour choisir un drapeau dans la liste
        int indexDrapeau = Random.Range(0, listeDrapeaux.Count);
        drapeauImage.sprite = listeDrapeaux[indexDrapeau]; // Met � jour l'image du drapeau

        // S�lectionne un index al�atoire pour la bonne r�ponse parmi les boutons
        bonIndex = Random.Range(0, boutonsOptions.Length);
        List<int> indicesUtilises = new List<int>(); // Liste pour stocker les indices d�j� utilis�s

        // Parcourt tous les boutons d'options pour les reinitialiser avec des noms de pays
        for (int i = 0; i < boutonsOptions.Length; i++)
        {
            int indexBouton = i; // Capture l'index actuel dans une variable locale
            boutonsOptions[i].onClick.RemoveAllListeners(); // Supprime tous les anciens auditeurs d'�v�nements
            boutonsOptions[i].onClick.AddListener(() => Reponse(indexBouton)); // Ajoute un nouvel auditeur d'�v�nements pour v�rifier la r�ponse

            // Si le bouton actuel est le bon, affiche le nom correct du pays
            if (i == bonIndex)
            {
                boutonsOptions[i].GetComponentInChildren<Text>().text = ObtenirNomDrapeau(listeDrapeaux[indexDrapeau].name);
            }
            else
            {
                Sprite mauvaisDrapeau; // Variable pour stocker un mauvais drapeau
                int indexHasard;

                // Boucle pour trouver un drapeau incorrect qui n'est pas d�j� utilis� � afficher comme option au joueur
                do
                {
                    indexHasard = Random.Range(0, listeDrapeaux.Count);
                    mauvaisDrapeau = listeDrapeaux[indexHasard];
                } while (mauvaisDrapeau.name == listeDrapeaux[indexDrapeau].name || indicesUtilises.Contains(indexHasard));

                // Met � jour le texte du bouton avec le nom du mauvais drapeau
                boutonsOptions[i].GetComponentInChildren<Text>().text = ObtenirNomDrapeau(mauvaisDrapeau.name);
                indicesUtilises.Add(indexHasard); // Ajoute cet index � la liste des indices utilis�s
            }
        }
    }


    /// <summary>
    /// V�rifie si la r�ponse s�lectionn�e par le joueur est correcte.
    /// </summary>
    /// <param name="index">Index du bouton s�lectionn�.</param>
    void Reponse(int index)
    {
        if (index == bonIndex)
        {
            score++; // on augmente le score
            texteScore.text = "Score: " + score;
        }
        ProchainDrapeau();
    }

    /// <summary>
    /// Obtient le nom du drapeau � partir du nom du sprite.
    /// </summary>
    /// <param name="nomDrapeau">Nom du sprite du drapeau.</param>
    /// <returns>Le nom du sprite du drapeau.</returns>
    string ObtenirNomDrapeau(string nomDrapeau)
    {
        return nomDrapeau;
    }

    /// <summary>
    /// G�re la fin du jeu lorsque le joueur atteint le score cible.
    /// </summary>
    void FinirJeu()
    {
        PreferencesJoueur.FinirJeuDrapeaux();
        finPartie.gameObject.SetActive(true);
        enTrainDeJouer = false;

        foreach (var button in boutonsOptions)
        {
            button.GetComponentInChildren<Text>().text = " ";
            button.interactable = false;
        }

        texteChronometre.gameObject.SetActive(false);
        drapeauImage.gameObject.SetActive(false);
        quitter.gameObject.SetActive(true);
    }

    /// <summary>
    /// Permet de quitter le jeu de drapeaux et de retourner � la sc�ne de jeu.
    /// </summary>
    public void Quitter()
    {
        SceneManager.LoadScene("SceneJeuV2");
    }
}
