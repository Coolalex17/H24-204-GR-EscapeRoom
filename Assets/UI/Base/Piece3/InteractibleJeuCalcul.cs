using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractibleJeuCalcul : MonoBehaviour
{

    public void InteractionDroite(Transform Joueur)
    {
        //pas utile presentement
    }

  
    public void InteractionGauche(Transform Joueur)
    {
        SceneManager.LoadScene("JeuMath");
    }
}
