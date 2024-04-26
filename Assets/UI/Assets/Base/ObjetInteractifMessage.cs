using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjetInteractifMessage : MonoBehaviour
{
  //Chatgpt

    public TextMeshPro messageTexte; // Assign this in the inspector
    public string messageAMontrer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure your player GameObject has the tag "Player"
        {
            messageTexte.text = messageAMontrer;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageTexte.text = "";
        }
    }
}
