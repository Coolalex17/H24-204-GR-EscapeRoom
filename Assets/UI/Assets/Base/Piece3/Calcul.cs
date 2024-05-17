using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Button quitter;

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

    private int ChoisirOperation()
    {
        int choix = Random.Range(1, 5);
        return choix;
    }
    private void GenererQuestion()
    {
        if (score < 10) // On génère une question seulement si le score est inférieur à 7.
        {
            int a;
            int b;
            int choix = ChoisirOperation();
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
                a = Random.Range(1, 30);
                b = Random.Range(1, 30);
                reponsePresentement = a * b;
                questionTexte.text = $"Qu'est-ce que {a} * {b}?";
            }
            else if (choix ==4)
            {
                a = Random.Range(1, 200);
                b = Random.Range(1, 200);
                if (a > b)
                {
                    Division(a, b);
                }
                else if (b >= a)
                {
                    Division(b,a);
                }
            }
        }
        else
        {

            PartieGagnee(); // Le joueur gagne le jeu s'il a un score de 7
        }
    }
    private void Division(int chiffre1, int chiffre2)
    {
        int nombreRestant = chiffre1 % chiffre2;
        reponsePresentement = (chiffre1 - nombreRestant) / chiffre2;
        questionTexte.text = $"Qu'est-ce que {chiffre1 - nombreRestant} / {chiffre2}?";
    }


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
        reponseTexte.text = ""; // On vide le inputfield après avoir envoyé une réponse
        if (score < 10)
        {
            GenererQuestion(); // On génère une nouvelle question
            ReinitialiserTemps(); // On recommence le chronomètre après une nouvelle question
        }
        else
        {
            PartieGagnee(); // La partie finit si le score est de 7

        }
    }

    private void AfficherTemps(float tempsAAfficher)
    {
        tempsAAfficher += 1;
        float minutes = Mathf.FloorToInt(tempsAAfficher / 60);
        float seconds = Mathf.FloorToInt(tempsAAfficher % 60);
        chronometre.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

   private void PartieGagnee()
    {
        // Implète la logique quand le joueur gagne
        PreferencesJoueur.GetSavedInventaire().Add(Inventaire.Items.CLEE_ORANGE);
        tempsEcoule = false;
        questionTexte.text = "Vous avez réussi! Cliquez sur Quitter";
        reponseBouton.interactable = false; // On empĉhe le joueur d'interagir avec le bouton s'il a gagné. 
        quitter.gameObject.SetActive(true);
        PreferencesJoueur.FinirJeuCalcul();
    }

       private void ReinitialiserTemps()
    {
        tempsRestant = tempsParQuestion; // On recommence le chronomètre après une nouvelle question
        tempsEcoule = true;
    }
    public void Quitter()
    {
        // Load or activate the school scene
        SceneManager.LoadScene("SceneJeuV2");
    }
}
