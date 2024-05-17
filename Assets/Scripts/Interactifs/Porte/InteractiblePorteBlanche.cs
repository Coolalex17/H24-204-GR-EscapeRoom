using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiblePorteBlanche : MonoBehaviour, Interactible
{
    /// <summary>
    /// Tout les scritps interactif porte blanche, rouge etc sont pareils la seule diff�rence �tant la cl�e requise
    /// Le code a du �tre fait de cette facon pour pouvoir maintenir un bool qui determine si la porte a �t� debar� pendant le jeu 
    /// puisque le syst�me de sauvegarde n'as pas �t� compl�t�
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
    /// Losrque la scene est charg�e, debare la porte si le joueur l'a deja fait
    /// </summary>
    public void Start() {
        anim = GetComponent<Animator>();
        if(ouvert) {
            Cadena.SetActive(false);
        }
    }
    public void InteractionGauche(Transform Joueur) {
        if (Joueur.GetComponent<Inventaire>().EnleverItem(Inventaire.Items.CLEE_BLANCHE, 1)) {//V�rifie et enl�ve la cl�e si le joueur la possede
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
    /// D�mare l'animation d'ouverture de la porte
    /// </summary>
    public void OpenDoor() {
        anim.SetTrigger("Open");
        isOpen = !isOpen;
    }

    /// <summary>
    /// D�mare l'animation de fermeture de porte
    /// </summary>
    public void CloseDoor() {
        anim.SetTrigger("Close");
        isOpen = !isOpen;
    }
}
