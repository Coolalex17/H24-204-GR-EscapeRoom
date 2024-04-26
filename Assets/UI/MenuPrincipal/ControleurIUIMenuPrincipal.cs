using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleurInterface : MonoBehaviour
{
    
    public void BtnJouer()
    {
        SceneManager.LoadScene("SceneOuverture");
    }

    public void BtnParametres()
    {
        
        PlayerPrefs.SetInt("SceneEnregistre", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MenuParametres");
       
    }

    public void BtnQuitter()
    {
        Application.Quit();
    }
}
