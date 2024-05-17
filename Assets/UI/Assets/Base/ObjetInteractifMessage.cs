using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Affiche un message lorsque le joueur entre en collision avec cet objet interactif.
/// </summary>
public class ObjetInteractifMessage : MonoBehaviour // ChatGPT
{
    public TextMeshPro messageTexte; // UIElement qui affiche le messageAMontrer.
    public string messageAMontrer; // Message � afficher d�fini dans l'inspecteur.

    /// <summary>
    /// Appel�e lorsque le joueur entre en collision avec cet objet interactif.
    /// </summary>
    /// <param name="autre">Le collider avec lequel la collision s'est produite.</param>
    private void OnTriggerEnter(Collider autre)
    {
        if (autre.CompareTag("Player")) // S'assure que le Collider autre a le tag "Player".
        {
            messageTexte.text = messageAMontrer; // Affiche le message.
        }
    }

    /// <summary>
    /// Appel�e lorsque le joueur sort de la collision avec cet objet interactif.
    /// </summary>
    /// <param name="autre">Le collider avec lequel la collision s'est produite.</param>
    private void OnTriggerExit(Collider autre)
    {
        if (autre.CompareTag("Player"))
        {
            messageTexte.text = ""; // Efface le message lorsque le joueur s'�loigne de la collision.
        }
    }
}
