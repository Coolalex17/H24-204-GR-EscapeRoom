using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractibleJeuEchecs : MonoBehaviour, Interactible
{
    public void InteractionDroite(Transform Joueur)
    {
        //pas utile presentement
    }

    //Load la sc�ne du jeu d'�checs
    public void InteractionGauche(Transform Joueur)
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("SceneJeuEchecs1");
    }


}
