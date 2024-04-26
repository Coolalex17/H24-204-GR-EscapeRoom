using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManagerPorte : MonoBehaviour
{
    private Animator maPorte = null;
 
    public bool ouvert = false;
    private bool ferme = false;


    // Update is called once per frame
    private void controlePorte(Collider autre)
    {
       
        if (autre.CompareTag("Player")) {
            if (ouvert)
            {
                maPorte.Play("PorteOuverte", 0, 0.0f);
                gameObject.SetActive(false);
            }
        else if (ferme)
            {
                maPorte.Play("DoorClosed", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }

    }
}
