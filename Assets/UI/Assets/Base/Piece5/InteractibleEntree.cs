using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleEntree : MonoBehaviour, Interactible
{
    [SerializeField] private CodeOrdinateur ordinateur;

    public void boutonPresse()
    {
        if (!ordinateur.IsReponseTrouvee())
        {
            ordinateur.Execute();
        }

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
