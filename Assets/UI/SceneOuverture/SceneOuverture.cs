using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gère les actions du menu d'ouverture du jeu.
/// </summary>
public class SceneOuverture : MonoBehaviour
{
    
    public void BtnContinuer()
    {
        //Le bouton Continuer permet au joueur de se rendre à la scène de jeu
        SceneManager.LoadScene("SceneJeuV2");
    }

   
    public void BtnQuitter()
    {
        //Le bouton Quitter permet de quitter le jeu
        Application.Quit();
    }
}
