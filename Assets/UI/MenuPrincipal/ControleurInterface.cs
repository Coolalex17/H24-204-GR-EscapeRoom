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
       
        SceneManager.LoadScene("MenuOption");
    }

    public void BtnQuitter()
    {
        Application.Quit();
    }
}
