using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tiroir : MonoBehaviour, Interactible
{
    //Chatgpt
    
    [SerializeField] private Animator tiroir;

    public Text messageTexte; // Assign this in the inspector
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

    public void Execute()
    {
            tiroir.SetBool("Open", true);
            StartCoroutine("Stop");
       
    }
    public void InteractionDroite(Transform Joueur)
    {
        //Rien pour l'Instant              
    }
    public void InteractionGauche(Transform Joueur)
    {
        Execute();
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.5f);
        tiroir.SetBool("Open", false);
        tiroir.enabled = false;
    }
}

