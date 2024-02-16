using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleurUISceneOuverture : MonoBehaviour
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
    
    public void BtnContinuer()
    {
        SceneManager.LoadScene("ScenePrincipale");
    }


}


