using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Gère les actions du menu principal du jeu.
/// </summary>
public class MenuPrincipal : MonoBehaviour
{
    
    public void BtnJouer()
    {
        //Bouton qui conduit le joueur à la scène d'ouverture
        SceneManager.LoadScene("SceneOuverture");
    }

    public void BtnParametres()
    {
        //Bouton permettant au joueur de se rendre au menu paramètres.
        PlayerPrefs.SetInt("SceneEnregistre", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MenuParametres");
       
    }

    public void BtnQuitter()
    {
        //Bouton pour quitter
        Application.Quit();
    }
}
