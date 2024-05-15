using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class JeuDrapeau : MonoBehaviour
{
    public Image drapeauImage;
    public List<Sprite> listeDrapeaux; // List to hold flag sprites
    public Button[] boutonsOptions; // Buttons to display country names
    public Text texteChronometre;
    public Text texteScore;

    private int bonIndex;
    private int score = 0;
    private float chronometre = 5.0f;
    private bool enTrainDeJouer = true;
    public Text finPartie;
    public Button quitter;

    void Start()
    {
        texteScore.text = "Score: " + score;
        ProchainDrapeau();
    }

    void Update()
    {
        if (!enTrainDeJouer) return;

        chronometre -= Time.deltaTime;
        texteChronometre.text =  Mathf.Round(chronometre).ToString();

        if (chronometre <= 0)
        {
            ProchainDrapeau();
        }
    }

    void ProchainDrapeau()
    {
        if (score >= 25)
        {
            PreferencesJoueur.FinirJeuDrapeaux();
            finPartie.gameObject.SetActive(true); // Show win message
            enTrainDeJouer = false; // Stop the game logic
            foreach (var button in boutonsOptions)
            {
                button.GetComponentInChildren<Text>().text = " ";
                button.interactable = false; // Disable all answer buttons
            }
            texteChronometre.gameObject.SetActive(false); // Optionally hide the timer
            drapeauImage.gameObject.SetActive(false); // Désactiver l'image du drapeau
                                                      // PreferencesJoueur.FinirJeuDrapeaux();
            quitter.gameObject.SetActive(true);
            return;
        }

        chronometre = 5.0f; // Reset the timer

        int indexDrapeau = Random.Range(0, listeDrapeaux.Count);
        drapeauImage.sprite = listeDrapeaux[indexDrapeau];

        bonIndex = Random.Range(0, boutonsOptions.Length);
        List<int> indicesUtilises = new List<int>(); // To avoid repeating countries

        for (int i = 0; i < boutonsOptions.Length; i++)
        {
            int indexBouton = i; // Capture the current index in a local variable
            boutonsOptions[i].onClick.RemoveAllListeners();
            boutonsOptions[i].onClick.AddListener(() => Reponse(indexBouton));

            if (i == bonIndex)
            {
                boutonsOptions[i].GetComponentInChildren<Text>().text = ObtenirNomDrapeau(listeDrapeaux[indexDrapeau].name);
            }
            else
            {
                Sprite mauvaisDrapeau;
                int indexHasard;
                do
                {
                    indexHasard = Random.Range(0, listeDrapeaux.Count);
                    mauvaisDrapeau = listeDrapeaux[indexHasard];
                } while (mauvaisDrapeau.name == listeDrapeaux[indexDrapeau].name || indicesUtilises.Contains(indexHasard));

                boutonsOptions[i].GetComponentInChildren<Text>().text = ObtenirNomDrapeau(mauvaisDrapeau.name);
                indicesUtilises.Add(indexHasard); // Add this index to the used list
            }
        }
    }



    void Reponse(int index)
    {
        
        if (index == bonIndex)
        {
            score++;
            texteScore.text = "Score: " + score;
            Debug.Log("Score Updated: " + score); // Confirm score is updated
        }
        ProchainDrapeau();
    }
    string ObtenirNomDrapeau(string flagName)
    {
        // Assuming the flag's name is the country name; adjust if it's not
        return flagName;
    }
    public void Quitter()
    {
        // Load or activate the school scene
        SceneManager.LoadScene("SceneJeuV2");
    }
}