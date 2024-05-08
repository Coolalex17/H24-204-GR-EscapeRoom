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

    //Load la scène du jeu d'échecs
    public void InteractionGauche(Transform Joueur)
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("SceneJeuEchecs1");
    }


}
