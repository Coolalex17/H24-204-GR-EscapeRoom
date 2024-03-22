using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Door : MonoBehaviour, Interactible
{
    private Animator anim;
    private bool isOpen = false;
    private bool entreCollition = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    /*
    private void OnTriggerEnter(Collider collider)
    {
        entreCollition = true;
    }

    private void OnTriggerExit(Collider collider)
    {
        entreCollition = false;
    }
    */

    public void InteractionGauche(Transform Joueur)
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
}
