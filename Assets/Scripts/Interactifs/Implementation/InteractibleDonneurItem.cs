using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleDonneurItem : MonoBehaviour, Interactible
{
    public Inventaire.Items itemADonner;
    public int quantitee;
    public bool peutRefaire;
    private bool donneItem;

    public void InteractionGauche(Transform Joueur)
    {
        if (donneItem && !peutRefaire)
        {
            return;
        }
        donneItem = true;
        Joueur.GetComponent<Inventaire>().AjouterItem(itemADonner, quantitee);

    }
    public void InteractionDroite(Transform Joueur) { }


}

