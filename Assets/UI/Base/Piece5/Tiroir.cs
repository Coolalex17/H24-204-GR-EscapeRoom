using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tiroir : MonoBehaviour, Interactible
{
    //Chatgpt
    public GameObject interactionCanvas; // Drag your World Space Canvas here via the Inspector
    [SerializeField] private Animator tiroir;

    private void Start()
    {
        // Ensure the interaction text is hidden initially
        if (interactionCanvas != null)
            interactionCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is tagged as 'Player'
        if (other.CompareTag("Player"))
        {
            // Show the interaction canvas
            if (interactionCanvas != null)
                interactionCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider is tagged as 'Player'
        if (other.CompareTag("Player"))
        {
            // Hide the interaction canvas
            if (interactionCanvas != null)
                interactionCanvas.SetActive(false);
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

