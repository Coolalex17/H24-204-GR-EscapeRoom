using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiblePorteBlanche : MonoBehaviour, Interactible
{
    private static bool ouvert = false;
    [SerializeField] GameObject Cadena;
    private Animator anim;
    private bool isOpen = false;
    public Inventaire.Items itemRequis;
    public int quantiteeItemRequis;


    public void InteractionDroite(Transform Joueur) {
        //pas utile presentement
    }
    public void Start() {
        anim = GetComponent<Animator>();
        if(ouvert) {
            Cadena.SetActive(false);
        }
    }
    public void InteractionGauche(Transform Joueur) {
        if (Joueur.GetComponent<Inventaire>().EnleverItem(Inventaire.Items.CLEE_BLANCHE, 1)) {
            ouvert = true;
            Debug.Log("Ouvert");
            Cadena.SetActive(false) ;
        }
        if (ouvert) {

                if (!GetIsOpen()) {
                    OpenDoor();
                } else {
                    CloseDoor();
                }
            


        }
    }
    public bool GetIsOpen() {
        return isOpen;
    }

    public void OpenDoor() {
        anim.SetTrigger("Open");
        isOpen = !isOpen;
    }

    public void CloseDoor() {
        anim.SetTrigger("Close");
        isOpen = !isOpen;
    }
}
