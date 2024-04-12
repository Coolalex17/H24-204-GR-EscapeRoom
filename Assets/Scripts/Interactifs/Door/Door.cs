using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using static Inventaire;

public class Door : MonoBehaviour, Interactible
{
    private Animator anim;
    private bool isOpen = false;
    public Inventaire.Items itemRequis;
    public int quantiteeItemRequis;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void InteractionGauche(Transform Joueur)
    {
        if (TestCle(Joueur))
        {
            if (!GetIsOpen())
            {
                OpenDoor();
            }
            else
            {
                CloseDoor();
            }
        }
    }

    public void InteractionDroite(Transform Joueur) { }


    public bool GetIsOpen()
    {
        return isOpen;
    }

    public void OpenDoor()
    {
        anim.SetTrigger("Open");
        isOpen = !isOpen;
    }

    public void CloseDoor()
    {
        anim.SetTrigger("Close");
        isOpen = !isOpen;
    }

    private bool TestCle(Transform Joueur)
    {

        Inventaire inventaireJoueur = Joueur.GetComponent<Inventaire>();
        if (inventaireJoueur.VerifierPossesionItem(itemRequis) >= quantiteeItemRequis)
        {
            inventaireJoueur.EnleverItem(itemRequis, quantiteeItemRequis);
            return true;
        }
        return false;


    }
}
