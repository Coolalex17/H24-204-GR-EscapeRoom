using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleurUISceneOuverture : MonoBehaviour
{
    
    public void BtnContinuer()
    {
        SceneManager.LoadScene("ScenePrincipale");
    }



    public void BtnQuitter()
    {
        Application.Quit();
    }
}


