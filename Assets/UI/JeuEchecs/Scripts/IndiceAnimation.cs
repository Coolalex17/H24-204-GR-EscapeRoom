using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndiceAnimation : MonoBehaviour
{
    public GameObject controlleur;
    public GameObject textIndice;
    public Vector3 positionFinale;

    private float tailleInitiale = 80f;
    private float tailleFinale = 24f;
    private float dureeAnimation = 1f; // Durée de l'animation en secondes
    private Vector3 positionInitiale;
    private bool debutAnimation = false;
    private float debutTempsAnimation; // Temps du début de l'animation de l'indice

    private float tempsFinDuJeu;
    private bool stopTextShow = false;
    private bool getTime = false;

    void Start()
    {
        controlleur = GameObject.FindGameObjectWithTag("GameController");
        positionInitiale = new Vector3(0, 0, -5f);
    }

    void Update()
    {
        if (controlleur.GetComponent<Jeu>().IsFinDuJeu() && !getTime)
        {
            getTime = true;
            tempsFinDuJeu = Time.time;
        }

        if (controlleur.GetComponent<Jeu>().IsFinDuJeu() && !stopTextShow)
        {
            textIndice.GetComponent<Text>().enabled = true;
            stopTextShow = ShowText();
        }


        if (stopTextShow && !debutAnimation)
        {
            debutAnimation = true;
            textIndice.GetComponent<Text>().enabled = true;
            debutTempsAnimation = Time.time;

        }

        if (debutAnimation)
        {
            AnimerTexte();
        }

    }

    // Affiche l'indice de chiffre au centre de l'écran pendant quelques secondes
    public bool ShowText()
    {
        float tempsTextShow = Time.time - tempsFinDuJeu;
        if (tempsTextShow >= 1)
        {
            textIndice.GetComponent<Text>().enabled = false;
            return true;
        }
        return false;
    }

    // Effectue l'animation de l'indice qui va se placer dans le coin de l'écran
    public void AnimerTexte()
    {
        float timeElapsed = Time.time - debutTempsAnimation;
        float progress = Mathf.Clamp01(timeElapsed / dureeAnimation);
        float tailleFont = textIndice.GetComponent<Text>().fontSize;

        // Update text size based on progress
        if (textIndice != null)
            tailleFont = Mathf.Lerp(tailleInitiale, tailleFinale, progress);
        else
            transform.localScale = Vector3.Lerp(Vector3.one * tailleInitiale, Vector3.one * tailleFinale, progress);

        textIndice.GetComponent<Text>().fontSize = (int)tailleFont;

        // Update text position based on progress
        transform.position = Vector3.Lerp(positionInitiale, positionFinale, progress);

        textIndice.transform.position = new Vector3(
         textIndice.transform.position.x,
         textIndice.transform.position.y,
         0f
     );
    }
}
