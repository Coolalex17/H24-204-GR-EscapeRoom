using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleOrdi : MonoBehaviour, Interactible
{
    [SerializeField] private CodeOrdinateur ordinateur;
    public int nombre;


    public void boutonPresse()
    {
        if (!ordinateur.IsReponseTrouvee())
        {
            ordinateur.Nombre(nombre);
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
