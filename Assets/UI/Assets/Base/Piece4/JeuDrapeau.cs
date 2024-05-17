using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe pour gérer le jeu de reconnaissance de drapeaux.
/// </summary>
public class JeuDrapeau : MonoBehaviour
{
    private float chronometre = 5.0f; // Temps par question
    public Image drapeauImage; // Image pour afficher le drapeau
    public List<Sprite> listeDrapeaux; // Liste des sprites de drapeaux
    public Button[] boutonsOptions; // Boutons pour afficher les noms des pays
    public Text texteChronometre; // Texte pour afficher le chronomètre
    public Text texteScore; // Texte pour afficher le score
    public Text finPartie; // Texte pour afficher le message de fin de partie
    public Button quitter; // Bouton pour quitter le jeu
    private int bonIndex; // Index de la bonne réponse de nom du drapeau affiché
    private int score = 0; // Score du joueur
    private bool enTrainDeJouer = true; // Indicateur de l'état du jeu

    /// <summary>
    /// Méthode appelée au démarrage du jeu.
    /// Initialise le score et affiche le premier drapeau.
    /// </summary>
    void Start()
    {
        texteScore.text = "Score: " + score;
        ProchainDrapeau();
    }

    /// <summary>
    /// Méthode appelée à chaque frame.
    /// Gère le chronomètre et le passage au drapeau suivant.
    /// </summary>
    void Update()
    {
        if (!enTrainDeJouer) return;

        chronometre -= Time.deltaTime;
        texteChronometre.text = Mathf.Round(chronometre).ToString();

        // Si 5 secondes ont été écoulées, on génère un nouveau drapeau.
        if (chronometre <= 0)
        {
            ProchainDrapeau();
        }
    }

    /// <summary>
    /// Sélectionne et affiche un nouveau drapeau, puis réinitialise le chronomètre.
    /// </summary>
    private void ProchainDrapeau()
    {
        // Vérifie si le joueur a atteint le score nécessaire pour gagner
        if (score >= 25)
        {
            FinirJeu(); // Appelle la méthode pour terminer le jeu

            return;
        }

        // Réinitialise le chronomètre à 5 secondes
        chronometre = 5.0f;

        // Sélectionne un index aléatoire pour choisir un drapeau dans la liste
        int indexDrapeau = Random.Range(0, listeDrapeaux.Count);
        drapeauImage.sprite = listeDrapeaux[indexDrapeau]; // Met à jour l'image du drapeau

        // Sélectionne un index aléatoire pour la bonne réponse parmi les boutons
        bonIndex = Random.Range(0, boutonsOptions.Length);
        List<int> indicesUtilises = new List<int>(); // Liste pour stocker les indices déjà utilisés

        // Parcourt tous les boutons d'options pour les reinitialiser avec des noms de pays
        for (int i = 0; i < boutonsOptions.Length; i++)
        {
            int indexBouton = i; // Capture l'index actuel dans une variable locale
            boutonsOptions[i].onClick.RemoveAllListeners(); // Supprime tous les anciens auditeurs d'événements
            boutonsOptions[i].onClick.AddListener(() => Reponse(indexBouton)); // Ajoute un nouvel auditeur d'événements pour vérifier la réponse

            // Si le bouton actuel est le bon, affiche le nom correct du pays
            if (i == bonIndex)
            {
                boutonsOptions[i].GetComponentInChildren<Text>().text = ObtenirNomDrapeau(listeDrapeaux[indexDrapeau].name);
            }
            else
            {
                Sprite mauvaisDrapeau; // Variable pour stocker un mauvais drapeau
                int indexHasard;

                // Boucle pour trouver un drapeau incorrect qui n'est pas déjà utilisé à afficher comme option au joueur
                do
                {
                    indexHasard = Random.Range(0, listeDrapeaux.Count);
                    mauvaisDrapeau = listeDrapeaux[indexHasard];
                } while (mauvaisDrapeau.name == listeDrapeaux[indexDrapeau].name || indicesUtilises.Contains(indexHasard));

                // Met à jour le texte du bouton avec le nom du mauvais drapeau
                boutonsOptions[i].GetComponentInChildren<Text>().text = ObtenirNomDrapeau(mauvaisDrapeau.name);
                indicesUtilises.Add(indexHasard); // Ajoute cet index à la liste des indices utilisés
            }
        }
    }


    /// <summary>
    /// Vérifie si la réponse sélectionnée par le joueur est correcte.
    /// </summary>
    /// <param name="index">Index du bouton sélectionné.</param>
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
    /// Obtient le nom du drapeau à partir du nom du sprite.
    /// </summary>
    /// <param name="nomDrapeau">Nom du sprite du drapeau.</param>
    /// <returns>Le nom du sprite du drapeau.</returns>
    string ObtenirNomDrapeau(string nomDrapeau)
    {
        return nomDrapeau;
    }

    /// <summary>
    /// Gère la fin du jeu lorsque le joueur atteint le score cible.
    /// </summary>
    void FinirJeu()
    {
        PreferencesJoueur.GetSavedInventaire().Add(Inventaire.Items.CLEE_JAUNE);
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
    /// Permet de quitter le jeu de drapeaux et de retourner à la scène de jeu.
    /// </summary>
    public void Quitter()
    {
        SceneManager.LoadScene("SceneJeuV2");
    }
}
