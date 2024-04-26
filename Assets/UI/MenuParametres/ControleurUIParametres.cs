using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class MenuParametres : MonoBehaviour
{

    public Dropdown qualiteDropdown;

    private void Start()
    {
        qualiteDropdown.onValueChanged.AddListener(delegate {
            ChangerQualite(qualiteDropdown);
        });
        int qualiteEnregistre = PlayerPrefs.GetInt("QualiteGraphique", QualitySettings.GetQualityLevel());
        qualiteDropdown.value = qualiteEnregistre;
    }
 
    //change qualité graphique
    public void ChangerQualite(Dropdown change)
    {
        QualitySettings.SetQualityLevel(change.value);
        PlayerPrefs.SetInt("QualiteGraphique", change.value);
        PlayerPrefs.Save();
    }

   public void MettrePleinEcran(bool pleinEcran)
    {
        Screen.fullScreen = pleinEcran;
        PlayerPrefs.Save();
    }
    public void ControlerBtnQuitter()
    {
        Application.Quit();
    }

    public void ControlerBtnRetour()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneEnregistre"));
        //https://www.youtube.com/watch?v=faYY3BNmAeA
        PlayerPrefs.Save();

    }












}
