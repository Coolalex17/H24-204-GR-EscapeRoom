using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using static Inventaire;

public class Door : MonoBehaviour, Interactible
{
    private Animator anim;
    private bool isOpen = false;
    
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
        /*  Inventaire inventaireJoueur = Joueur.GetComponent<Inventaire>();
          List<Items> list;
          bool avoirCle = false;
          list = inventaireJoueur.ObtenirInventaire();
          for (int i = 0; i < list.Count; i++)
          {
              avoirCle = (list[i] == Items.CLEE_PORTE1);
              if (avoirCle)
              {
                  i = list.Count;
              }
          }
          return avoirCle;*/

        Inventaire inventaireJoueur = Joueur.GetComponent<Inventaire>();
        if (inventaireJoueur.VerifierPossesionItem(Items.CLEE_PORTE1) > 0)
        {
            return true;
        }
        return false;


    }
}
