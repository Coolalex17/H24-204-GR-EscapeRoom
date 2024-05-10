using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PorteFinale : MonoBehaviour, Interactible
{
    public void InteractionDroite(Transform Joueur) {
        //pas utile presentement
    }

    //Load la scène de fin de jeu
    public void InteractionGauche(Transform Joueur) {
        if(Joueur.GetComponent<Inventaire>().VerifierPossesionItem(Inventaire.Items.CLEE_PORTE1) >0 ) {
            Debug.Log("Fini");
            SceneManager.LoadScene("SceneFinale");
        }
        

    }
}
