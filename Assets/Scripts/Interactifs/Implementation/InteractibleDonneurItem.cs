using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleDonneurItem : MonoBehaviour, Interactible
{
    public Inventaire.Items itemADonner;//le type ditem qui sera donne
    public int quantitee; //Quantite ditems qui seron donne
    public bool peutRefaire; //Determine si le joueur peut appuyer a nouveau sur lintreractible pour obtenir dautres items
    private bool donneItem;
    
    
    
    
    /// <summary>
    /// Donne litem voulu au joueur
    /// </summary>
    /// <param name="Joueur"></param>
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

