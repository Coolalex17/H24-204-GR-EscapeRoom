using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleTest : MonoBehaviour ,Interactible
{
    public void InteractionDroite() {
        Debug.Log("Click droit");
    }

    public void InteractionGauche() {
        Debug.Log("Click gauche");
    }

}
