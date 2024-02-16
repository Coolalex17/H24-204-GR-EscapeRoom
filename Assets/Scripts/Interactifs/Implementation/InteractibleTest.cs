using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleTest : MonoBehaviour ,Interactible
{
    public void InteractionDroite(Transform Joueur) {
        Debug.Log("Click droit");
    }

    public void InteractionGauche(Transform Joueur) {
        Debug.Log("Click gauche");
    }

}
