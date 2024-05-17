using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// G�re les actions du menu principal du jeu.
/// </summary>
public class MenuPrincipal : MonoBehaviour
{
    
    public void BtnJouer()
    {
        //Bouton qui conduit le joueur � la sc�ne d'ouverture
        SceneManager.LoadScene("SceneOuverture");
    }

    public void BtnParametres()
    {
        //Bouton permettant au joueur de se rendre au menu param�tres.
        PlayerPrefs.SetInt("SceneEnregistre", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MenuParametres");
       
    }

    public void BtnQuitter()
    {
        //Bouton pour quitter
        Application.Quit();
    }
}
