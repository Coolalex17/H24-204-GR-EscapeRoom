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
        SceneManager.LoadScene("ScenePrincipale");
    }

    public void BtnParametres()
    {
        SceneManager.LoadScene("MenuOption");
    }

    public void BtnQuitter()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
