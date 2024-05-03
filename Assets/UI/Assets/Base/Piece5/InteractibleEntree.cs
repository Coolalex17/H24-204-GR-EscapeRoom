using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleEntree : MonoBehaviour, Interactible
{
    [SerializeField] private CodeOrdinateur ordinateur;

    public void boutonPresse()
    {
        ordinateur.Execute();
        Debug.Log("Button pressed!");
    }

    public void InteractionDroite(Transform Joueur)
    {
        //Rien pour l'Instant              
    }
    public void InteractionGauche(Transform Joueur)
    {
        boutonPresse();
    }
}
