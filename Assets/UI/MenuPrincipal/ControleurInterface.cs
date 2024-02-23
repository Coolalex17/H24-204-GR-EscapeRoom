using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleurInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    //panel
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BtnJouer()
    {
       //panel.GetComponent<Image>().color = Color.white;
        SceneManager.LoadScene("SceneOuverture");
    }

    public void BtnParametres()
    {
        //It grabs the number of my current scene
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MenuParametres");
    }

    public void BtnQuitter()
    {
        Application.Quit();
    }
}
