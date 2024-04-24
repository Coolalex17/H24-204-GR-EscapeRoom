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

    private int currentAnswer;


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
                GenererQuestion(); // Generate new question when time runs out

                ReinitialiserTemps(); // Reset and restart the timer
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
        if (score < 7) // Only generate a new question if the score is less than 7
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
                    currentAnswer = a + b;
                    questionTexte.text = $"Qu'est-ce que {a} + {b}?";
                }
                else
                {
                    currentAnswer = a - b;
                    questionTexte.text = $"Qu'est-ce que {a} - {b}?";
                }
            }
            else if (choix == 3)
            {
                a = Random.Range(1, 40);
                b = Random.Range(1, 40);
                currentAnswer = a * b;
                questionTexte.text = $"Qu'est-ce que {a} * {b}?";
            }
            else
            {
                a = Random.Range(1, 100);
                b = Random.Range(1, 100);
                if (a > b)
                {
                    division(a, b);
                }
                else
                {
                    division(b, a);
                }
            }
        }
        else
        {
            PartieGagnee(); // Player wins the game if score reaches 7
        }
    }
    void division(int chiffre1, int chiffre2)
    {
        int nombreRestant = chiffre1 % chiffre2;
        currentAnswer = (chiffre1 + nombreRestant) / chiffre2;
        questionTexte.text = $"Qu'est-ce que {chiffre1 + nombreRestant} * {chiffre2}?";
    }


    public void VerifierReponse()
    {
        if (int.TryParse(reponseTexte.text, out int reponseJoueur))
        {
            if (reponseJoueur == currentAnswer)
            {
                score++;
                scoreTexte.text = "Score: " + score;

            }
        }
        reponseTexte.text = ""; // Clear input field after submission
        if (score < 7)
        {
            GenererQuestion(); // Generate a new question on correct answer
            ReinitialiserTemps(); // Reset the timer after generating a new question
        }
        else
        {
            PartieGagnee(); // Ends the game if the score reaches 7

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
        // Implement what happens when player wins
        tempsEcoule = false;
        questionTexte.text = "Vous avez réussi!";
        reponseBouton.interactable = false; // Disable the button 
    }

    void ReinitialiserTemps()
    {
        tempsRestant = tempsParQuestion; // Reset the timer for a new question
        tempsEcoule = true; // Make sure the timer starts running after reset
    }
}
