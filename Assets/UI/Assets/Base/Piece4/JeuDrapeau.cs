using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Sprites;

public class JeuDrapeau : MonoBehaviour //ChatGPT
{
    public Image imageDrapeau;
    public List<Sprite> listeDrapeaux; // Liste de tous les drapeaux
    public Button[] nomsDeDrapeaux; //boutons qui affichent des noms possibles pour le drapeau affiché
    public Text texteChronometre;
    public Text scoreTexte;

    private int indexCorrect;
    private int score = 0;
    private float temps = 3.0f;
    private bool estEnTrainDeJouer = true;
    public Text finPartie;

    void Start()
    {

        scoreTexte.text = "Score : " + score;
        ProchainDrapeau();
    }

    void Update()
    {
        if (!estEnTrainDeJouer) return;

        temps -= Time.deltaTime;
        texteChronometre.text =  Mathf.Round(temps).ToString();

        if (temps <= 0)
        {
            ProchainDrapeau();
        }
    }

    private void ProchainDrapeau()
    {
        if (score >= 25)
        {
          
            finPartie.gameObject.SetActive(true); // Affiche que la partie est gagnée
            estEnTrainDeJouer = false; // Arrête la logique du jeu
            foreach (var button in nomsDeDrapeaux)
            {
                button.interactable = false; // Désactive les boutons
            }
            texteChronometre.gameObject.SetActive(false); // Cache le chronomètre
            return;
        }

        temps = 3.0f; // Réinitialise le temps

        int indexDrapeau = Random.Range(0, listeDrapeaux.Count);
        imageDrapeau.sprite = listeDrapeaux[indexDrapeau];

        indexCorrect = Random.Range(0, nomsDeDrapeaux.Length);
        List<int> indexsUtilises = new List<int>(); // Empêche de donner des noms identiques comme choix

        for (int i = 0; i < nomsDeDrapeaux.Length; i++)
        {
            int indexBouton = i; // Sauvegarde l'index dans une variable temporaire
            nomsDeDrapeaux[i].onClick.RemoveAllListeners();
            nomsDeDrapeaux[i].onClick.AddListener(() => Reponse(indexBouton));

            if (i == indexCorrect)
            {
                nomsDeDrapeaux[i].GetComponentInChildren<Text>().text = ObtenirLeNomDuDrapeau(listeDrapeaux[indexDrapeau].name);
            }
            else
            {
                Sprite mauvaisDrapeau;
                int indexAuHasard;
                do
                {
                    indexAuHasard = Random.Range(0, listeDrapeaux.Count);
                    mauvaisDrapeau = listeDrapeaux[indexAuHasard];
                } while (mauvaisDrapeau.name == listeDrapeaux[indexDrapeau].name || indexsUtilises.Contains(indexAuHasard));

                nomsDeDrapeaux[i].GetComponentInChildren<Text>().text = ObtenirLeNomDuDrapeau(mauvaisDrapeau.name);
                indexsUtilises.Add(indexAuHasard); 
            }
        }
    }


    private void Reponse(int index)
    {
      
        if (index == indexCorrect)
        {
            score++;
            scoreTexte.text = "Score: " + score;
          
        }
        ProchainDrapeau();
    }


    string ObtenirLeNomDuDrapeau(string nomDrapeau)
    {
       
        return nomDrapeau;
    }
}

