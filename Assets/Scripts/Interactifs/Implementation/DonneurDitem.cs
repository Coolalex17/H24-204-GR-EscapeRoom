using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DonneurDitem : MonoBehaviour, Interactible
{
    [SerializeField] Inventaire.Items itemGauche;
    [SerializeField] Inventaire.Items itemDroit;
    [SerializeField] private AudioSource sourceAudio;


    public void InteractionDroite(Transform Joueur)
    {
        AudioManager.jouerEffetSonore(sourceAudio);   
        Inventaire inventaireJoueur = Joueur.GetComponent<Inventaire>();
        inventaireJoueur.AjouterItem(itemGauche, 1);
    }

    public void InteractionGauche(Transform Joueur)
    {
        Inventaire inventaireJoueur = Joueur.GetComponent<Inventaire>();
        inventaireJoueur.AjouterItem(itemDroit, 1);

    }
}
