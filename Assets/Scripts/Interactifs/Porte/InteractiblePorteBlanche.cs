using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiblePorteBlanche : MonoBehaviour, Interactible
{
    /// <summary>
    /// Tout les scritps interactif porte blanche, rouge etc sont pareils la seule différence étant la clée requise
    /// Le code a du être fait de cette facon pour pouvoir maintenir un bool qui determine si la porte a été debaré pendant le jeu 
    /// puisque le système de sauvegarde n'as pas été complété
    /// </summary>
    private static bool ouvert = false;
    [SerializeField] GameObject Cadena;
    private Animator anim;
    private bool isOpen = false;
    //public Inventaire.Items itemRequis;
    //public int quantiteeItemRequis;


    public void InteractionDroite(Transform Joueur) {
        //pas utile presentement
    }
    /// <summary>
    /// Losrque la scene est chargée, debare la porte si le joueur l'a deja fait
    /// </summary>
    public void Start() {
        anim = GetComponent<Animator>();
        if(ouvert) {
            Cadena.SetActive(false);
        }
    }
    public void InteractionGauche(Transform Joueur) {
        if (Joueur.GetComponent<Inventaire>().EnleverItem(Inventaire.Items.CLEE_BLANCHE, 1)) {//Vérifie et enlève la clée si le joueur la possede
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

    /// <summary>
    /// Démare l'animation d'ouverture de la porte
    /// </summary>
    public void OpenDoor() {
        anim.SetTrigger("Open");
        isOpen = !isOpen;
    }

    /// <summary>
    /// Démare l'animation de fermeture de porte
    /// </summary>
    public void CloseDoor() {
        anim.SetTrigger("Close");
        isOpen = !isOpen;
    }
}
