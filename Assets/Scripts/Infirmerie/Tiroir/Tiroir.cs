using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe pour g�rer les interactions avec un tiroir.
/// Impl�mente l'interface Interactible.
/// </summary>
public class Tiroir : MonoBehaviour, Interactible
{
   
    [SerializeField] private Animator tiroir; //Animator du tiroir, assign�e dans l'inspecteur.
    public Text messageTexte; // Text UI pour afficher un message quand le joueur s'approche du tiroir
    public string messageAMontrer; // Message � afficher lorsqu'un joueur entre en collision avec le tiroir.

    /// <summary>
    /// M�thode appel�e lorsqu'un autre collider (joueur) entre en collision avec le tiroir.
    /// </summary>
    /// <param name="autre">Le collider joueur.</param>
    private void OnTriggerEnter(Collider autre)
    {
        // V�rifie si le collider autre a le tag "Player"
        if (autre.CompareTag("Player"))
        {
            // Affiche le message
            messageTexte.text = messageAMontrer;
        }
    }

    /// <summary>
    /// M�thode appel�e lorsque le joueur sort de la collision avec celui de ce GameObject.
    /// </summary>
    /// <param name="autre">Le joueur.</param>
    private void OnTriggerExit(Collider autre)
    {
        // V�rifie si le collider autre a le tag "Player"
        if (autre.CompareTag("Player"))
        {
            // Efface le message
            messageTexte.text = "";
        }
    }

    /// <summary>
    /// Ex�cute l'animation d'ouverture du tiroir.
    /// </summary>
    public void Execute()
    {
        tiroir.SetBool("Open", true);
        StartCoroutine("Stop");
    }


    public void InteractionDroite(Transform Joueur)
    {
        // Actuellement pas utilis�e
    }

    /// <summary>
    /// M�thode appel�e lorsqu'un joueur interagit avec l'objet avec un clic gauche.
    /// D�clenche l'animation d'ouverture du tiroir.
    /// </summary>
    /// <param name="Joueur">Le transform du joueur.</param>
    public void InteractionGauche(Transform Joueur)
    {
        Execute();
    }

    /// <summary>
    /// Coroutine pour arr�ter l'animation apr�s un d�lai.
    /// </summary>
    private IEnumerator Stop()
    {
        // Attend 0.5 secondes
        yield return new WaitForSeconds(0.5f);
        // R�initialise l'�tat de l'animation et d�sactive l'Animator
        tiroir.SetBool("Open", false);
        tiroir.enabled = false;
    }
}

