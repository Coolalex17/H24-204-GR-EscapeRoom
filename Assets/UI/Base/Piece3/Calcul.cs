using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class Calcul : MonoBehaviour //ChatGpt
{
    public Text questionTexte;
    public InputField reponseTexte;
    public Text chronometre;
    public Text scoreTexte;
    public Button reponseBouton;

    private int score = 0;
    private float tempsParQuestion = 10; 
    private float tempsRestant;
    private bool tempsEcoule = false;

    private int reponsePresentement;
    public Text finPartie;

    void Start()
    {
        scoreTexte.text = "Score: " + score;
        GenererQuestion();
        ReinitialiserTemps();
        reponseBouton.onClick.AddListener(VerifierReponse);
    }

    void Update()
    {
        if (tempsEcoule)
        {
            if (tempsRestant > 0)
            {
                tempsRestant -= Time.deltaTime;
                AfficherTemps(tempsRestant);
            }
            else
            {
                tempsRestant = 0;
                tempsEcoule = false;
                GenererQuestion(); // Générer une nouvelle question quand le chronomètre finit

                ReinitialiserTemps(); // Reinitialiser et recommencer le chronomètre
            }
        }
    }

    public int choisirOperation()
    {
        int choix = Random.Range(1, 5);
        return choix;
    }
    void GenererQuestion()
    {
        if (score < 7) // On génère une question seulement si le score est inférieur à 7.
        {
            int a;
            int b;
            int choix = choisirOperation();
            if (choix == 1 || choix == 2)
            {
                a = Random.Range(1, 1000);
                b = Random.Range(1, 1000);
                if (choix == 1)
                {
                    reponsePresentement = a + b;
                    questionTexte.text = $"Qu'est-ce que {a} + {b}?";
                }
                else
                {
                    reponsePresentement = a - b;
                    questionTexte.text = $"Qu'est-ce que {a} - {b}?";
                }
            }
            else if (choix == 3)
            {
                a = Random.Range(1, 40);
                b = Random.Range(1, 40);
                reponsePresentement = a * b;
                questionTexte.text = $"Qu'est-ce que {a} * {b}?";
            }
            else if (choix ==4)
            {
                a = Random.Range(1, 100);
                b = Random.Range(1, 100);
                if (a > b)
                {
                    division(a, b);
                }
                else if (b >= a)
                {
                    division(b, a);
                }
            }
        }
        else
        {
            PartieGagnee(); // Le joueur gagne le jeu s'il a un score de 7
        }
    }
    void division(int chiffre1, int chiffre2)
    {
        int nombreRestant = chiffre1 % chiffre2;
        reponsePresentement = (chiffre1 - nombreRestant) / chiffre2;
        questionTexte.text = $"Qu'est-ce que {chiffre1 - nombreRestant} * {chiffre2}?";
    }


    public void VerifierReponse()
    {
        if (int.TryParse(reponseTexte.text, out int reponseJoueur))
        {
            if (reponseJoueur == reponsePresentement)
            {
                score++;
                scoreTexte.text = "Score: " + score;

            }
        }
        reponseTexte.text = ""; // On vide le inputfield après avoir envoyé une réponse
        if (score < 7)
        {
            GenererQuestion(); // On génère une nouvelle question
            ReinitialiserTemps(); // On recommence le chronomètre après une nouvelle question
        }
        else
        {
            PartieGagnee(); // La partie finit si le score est de 7

        }
    }

    void AfficherTemps(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        chronometre.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void PartieGagnee()
    {
        // Implète la logique quand le joueur gagne
        tempsEcoule = false;
        questionTexte.text = "Vous avez réussi!";
        reponseBouton.interactable = false; // On empĉhe le joueur d'interagir avec le bouton s'il a gagné. 
        finPartie.gameObject.SetActive(true); // Show win message
    }

        void ReinitialiserTemps()
    {
        tempsRestant = tempsParQuestion; // On recommence le chronomètre après une nouvelle question
        tempsEcoule = true;
    }
}
