using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiblePorteNoir : MonoBehaviour, Interactible
{
    private static bool ouvert = false;
    [SerializeField] GameObject Cadena;
    private Animator anim;
    private bool isOpen = false;


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
        if (Joueur.GetComponent<Inventaire>().EnleverItem(Inventaire.Items.CLEE_NOIR, 1)) {
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
