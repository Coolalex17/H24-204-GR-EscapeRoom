using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonneurDeClee : MonoBehaviour, Interactible
{
    
    public void InteractionDroite(Transform Joueur)
    {
     
     Inventaire inventaireJoueur = Joueur.GetComponent<Inventaire>();
        inventaireJoueur.AjouterItem(Inventaire.Items.CLEE_PORTE1,1);
    }

    public void InteractionGauche(Transform Joueur)
    {
        Debug.Log(Joueur.GetComponent<Inventaire>().VerifierPossesionItem(Inventaire.Items.CLEE_PORTE1));    
    }

}
