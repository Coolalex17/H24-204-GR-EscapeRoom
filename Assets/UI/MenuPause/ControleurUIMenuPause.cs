using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleurUIMenuPause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnContinuer()
    {
        SceneManager.LoadScene("SceneJeuV2");
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
