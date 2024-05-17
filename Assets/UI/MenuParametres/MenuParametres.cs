using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// Gère les paramètres du menu, tels que la qualité graphique, le plein écran et le changement de scène.
/// </summary>
public class MenuParametres : MonoBehaviour
{
    
    public Dropdown qualiteDropdown; // Dropdown permettant de sélectionner la qualité graphique.

    private void Start()
    {
        // Ajoute un écouteur d'événement pour détecter les changements de qualité graphique.
        qualiteDropdown.onValueChanged.AddListener(delegate {
            ChangerQualite(qualiteDropdown);
        });

        // Récupère la qualité graphique enregistrée dans les préférences du joueur et l'applique au Dropdown.
        int qualiteEnregistree = PlayerPrefs.GetInt("QualiteGraphique", QualitySettings.GetQualityLevel());
        qualiteDropdown.value = qualiteEnregistree;
    }

    /// <summary>
    /// Change la qualité graphique en fonction de la sélection dans le Dropdown de la scène du menu de paramètres.
    /// </summary>
    /// <param name="change">Dropdown de qualité graphique choisi par le joueur.</param>
    public void ChangerQualite(Dropdown change)
    {
        QualitySettings.SetQualityLevel(change.value);
        PlayerPrefs.SetInt("QualiteGraphique", change.value);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Active ou désactive le mode plein écran.
    /// </summary>
    /// <param name="pleinEcran"> Booléen indiquant si le mode plein écran doit être activé ou désactivé.</param>
    public void MettrePleinEcran(bool pleinEcran)
    {
        Screen.fullScreen = pleinEcran;
        PlayerPrefs.Save();
    }

  
    public void ControlerBtnQuitter()
    {
        //Méthode assignée au bouton Quitter du menu paramètres pour quitter le jeu.
        Application.Quit(); 
    }

   
    public void ControlerBtnRetour()
    {
        //https://www.youtube.com/watch?v=faYY3BNmAeA
        //Méthode assignée au bouton Retour du menu paramètres pour retourner à la scène précédente.
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneEnregistre")); 
        PlayerPrefs.Save();
    }
}














