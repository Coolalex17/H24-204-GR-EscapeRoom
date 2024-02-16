using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleurInterface : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
    //panel
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Btn1()
    {
        
        Debug.Log("btn1");
        panel.GetComponent<Image>().color = Color.white;
        
        SceneManager.LoadScene("ScenePrincipale");

    }



}
