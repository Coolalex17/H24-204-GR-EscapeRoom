using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleCoffre : MonoBehaviour , Interactible
{
    public Animator animateurCoffre;
    public void InteractionDroite(Transform Joueur)
{
    
}

public void InteractionGauche(Transform Joueur)
{
    animateurCoffre.Play("TreasureChest_OPEN", 0);
}

}
