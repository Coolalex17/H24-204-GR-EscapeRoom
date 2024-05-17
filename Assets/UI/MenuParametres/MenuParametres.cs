using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// G�re les param�tres du menu, tels que la qualit� graphique, le plein �cran et le changement de sc�ne.
/// </summary>
public class MenuParametres : MonoBehaviour
{
    
    public Dropdown qualiteDropdown; // Dropdown permettant de s�lectionner la qualit� graphique.

    private void Start()
    {
        // Ajoute un �couteur d'�v�nement pour d�tecter les changements de qualit� graphique.
        qualiteDropdown.onValueChanged.AddListener(delegate {
            ChangerQualite(qualiteDropdown);
        });

        // R�cup�re la qualit� graphique enregistr�e dans les pr�f�rences du joueur et l'applique au Dropdown.
        int qualiteEnregistree = PlayerPrefs.GetInt("QualiteGraphique", QualitySettings.GetQualityLevel());
        qualiteDropdown.value = qualiteEnregistree;
    }

    /// <summary>
    /// Change la qualit� graphique en fonction de la s�lection dans le Dropdown de la sc�ne du menu de param�tres.
    /// </summary>
    /// <param name="change">Dropdown de qualit� graphique choisi par le joueur.</param>
    public void ChangerQualite(Dropdown change)
    {
        QualitySettings.SetQualityLevel(change.value);
        PlayerPrefs.SetInt("QualiteGraphique", change.value);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Active ou d�sactive le mode plein �cran.
    /// </summary>
    /// <param name="pleinEcran"> Bool�en indiquant si le mode plein �cran doit �tre activ� ou d�sactiv�.</param>
    public void MettrePleinEcran(bool pleinEcran)
    {
        Screen.fullScreen = pleinEcran;
        PlayerPrefs.Save();
    }

  
    public void ControlerBtnQuitter()
    {
        //M�thode assign�e au bouton Quitter du menu param�tres pour quitter le jeu.
        Application.Quit(); 
    }

   
    public void ControlerBtnRetour()
    {
        //https://www.youtube.com/watch?v=faYY3BNmAeA
        //M�thode assign�e au bouton Retour du menu param�tres pour retourner � la sc�ne pr�c�dente.
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneEnregistre")); 
        PlayerPrefs.Save();
    }
}














