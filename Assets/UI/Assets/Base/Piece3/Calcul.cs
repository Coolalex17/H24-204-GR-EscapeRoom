using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Cette classe gère un jeu de calcul.
/// </summary>
public class Calcul : MonoBehaviour //ChatGPT
{
    
    private const float TEMPS_PAR_QUESTION = 10; // Constante définissant le temps alloué pour chaque question.
    public Text questionTexte;// Texte affichant la question de calcul.
    public InputField reponseTexte; // Champ de saisie pour la réponse du joueur.
    public Text chronometre;// Texte affichant le chronomètre.    
    public Text scoreTexte;// Texte affichant le score du joueur.    
    public Button reponseBouton;// Bouton pour soumettre la réponse.    
    private int score = 0;// Score du joueur.    
    private float tempsRestant;// Temps restant pour la question actuelle.    
    private bool tempsEcoule = false;// Indique si le temps est écoulé pour la question actuelle.    
    private int reponsePresentement;// Réponse correcte pour la question actuelle.    
    public Button quitter;// Bouton pour quitter le jeu.

    /// <summary>
    /// Méthode appelée au démarrage du jeu pour initialiser les éléments.
    /// </summary>
    void Start()
    {
        // Initialisation du score et affichage initial.
        scoreTexte.text = "Score: " + score;

        // Génération de la première question.
        GenererQuestion();

        // Réinitialisation du chronomètre.
        ReinitialiserTemps();

        // Ajout d'un listener pour le bouton de réponse.
        reponseBouton.onClick.AddListener(VerifierReponse);
    }

    /// <summary>
    /// Méthode appelée à chaque frame pour mettre à jour le chronomètre.
    /// </summary>
    void Update()
    {
        // Si le temps n'est pas écoulé, décrémente le temps restant.
        if (tempsEcoule)
        {
            if (tempsRestant > 0)
            {
                tempsRestant -= Time.deltaTime;
                AfficherTemps(tempsRestant);
            }
            else
            {
                // Si le temps est écoulé, générer une nouvelle question et réinitialiser le chronomètre.
                tempsRestant = 0;
                tempsEcoule = false;
                GenererQuestion();
                ReinitialiserTemps();
            }
        }
    }

    /// <summary>
    /// Choisit aléatoirement une opération arithmétique (addition, soustraction, multiplication, division).
    /// </summary>
    /// <returns>Un entier représentant l'opération choisie.</returns>
    private int ChoisirOperation()
    {
        int choix = Random.Range(1, 5);
        return choix;
    }

    /// <summary>
    /// Génère une nouvelle question de calcul basée sur une opération arithmétique aléatoire.
    /// </summary>
    private void GenererQuestion()
    {
        if (score < 10) // On génère une question seulement si le score est inférieur à 10.
        {
            int a, b;
            int choix = ChoisirOperation();
            if (choix == 1 || choix == 2)
            {
                //On génére deux nombres au hasard entre 1 et 1000 pour faire notre opération
                a = Random.Range(1, 1000);
                b = Random.Range(1, 1000);
                if (choix == 1) // Si le choix d'opération est 1, on crée une addition
                {
                    reponsePresentement = a + b;
                    questionTexte.text = $"Qu'est-ce que {a} + {b}?";
                }
                else // Si le choix est 2, on crée une soustraction
                {
                    reponsePresentement = a - b;
                    questionTexte.text = $"Qu'est-ce que {a} - {b}?";
                }
            }
            else if (choix == 3) 
            {
                // Si le choix est 3, on génére deux nombres entre 1 et 30 et on crée un multiplication
                a = Random.Range(1, 30);
                b = Random.Range(1, 30);
                reponsePresentement = a * b;
                questionTexte.text = $"Qu'est-ce que {a} * {b}?";
            }
            else if (choix == 4)
            {
                // Si le choix est 4, on génére deux nombres entre 1 et 200 et on crée une division
                a = Random.Range(1, 200);
                b = Random.Range(1, 200);
                if (a > b)
                {
                    Division(a, b);
                }
                else
                {
                    Division(b, a);
                }
            }
        }
        else
        {
            PartieGagnee(); // Le joueur gagne le jeu si le score est de 10.
        }
    }

    /// <summary>
    /// Génère une question de division où les nombres sont choisis de manière à éviter des divisions avec reste.
    /// </summary>
    /// <param name="chiffre1">Le dividende.</param>
    /// <param name="chiffre2">Le diviseur.</param>
    private void Division(int chiffre1, int chiffre2)
    {
        int nombreRestant = chiffre1 % chiffre2;
        reponsePresentement = (chiffre1 - nombreRestant) / chiffre2;
        questionTexte.text = $"Qu'est-ce que {chiffre1 - nombreRestant} / {chiffre2}?";
    }

    /// <summary>
    /// Vérifie si la réponse du joueur est correcte et met à jour le score en conséquence.
    /// </summary>
    private void VerifierReponse()
    {
        if (int.TryParse(reponseTexte.text, out int reponseJoueur))
        {
            if (reponseJoueur == reponsePresentement)
            {
                score++;
                scoreTexte.text = "Score: " + score;
            }
        }
        // Vide le champ de saisie après avoir envoyé une réponse.
        reponseTexte.text = "";

        // Génère une nouvelle question si le score est inférieur à 10, sinon termine la partie.
        if (score < 10)
        {
            GenererQuestion();
            ReinitialiserTemps();
        }
        else
        {
            PartieGagnee();
        }
    }

    /// <summary>
    /// Affiche le temps restant au format MM:SS.
    /// </summary>
    /// <param name="tempsAAfficher">Temps restant en secondes.</param>
    private void AfficherTemps(float tempsAAfficher)
    {
        tempsAAfficher += 1;
        float minutes = Mathf.FloorToInt(tempsAAfficher / 60);
        float seconds = Mathf.FloorToInt(tempsAAfficher % 60);
        chronometre.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    /// <summary>
    /// Gère la logique lorsque le joueur gagne la partie.
    /// </summary>
    private void PartieGagnee()
    {
        // Arrête le chronomètre et affiche un message de victoire.
        tempsEcoule = false;
        questionTexte.text = "Vous avez réussi! Cliquez sur Quitter";
        reponseBouton.interactable = false; // Désactive le bouton de réponse.
        quitter.gameObject.SetActive(true); // Active le bouton de quitter.
        PreferencesJoueur.FinirJeuCalcul(); // Appelle une méthode pour empêcher le joueur d'accéder une nouvelle fois au jeu.
    }

    /// <summary>
    /// Réinitialise le chronomètre pour la prochaine question.
    /// </summary>
    private void ReinitialiserTemps()
    {
        tempsRestant = TEMPS_PAR_QUESTION;
        tempsEcoule = true;
    }

    /// <summary>
    /// Charge la scène de jeu lorsque le joueur quitte le jeu de calcul.
    /// </summary>
    public void Quitter()
    {
        SceneManager.LoadScene("SceneJeuV2");
    }
}
