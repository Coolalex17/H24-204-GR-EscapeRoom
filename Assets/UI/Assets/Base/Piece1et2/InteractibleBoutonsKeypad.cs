using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet à un joueur d'interagir avec des boutons d'un clavier.
/// </summary>
public class InteractibleBoutonsKeypad : MonoBehaviour, Interactible
{
    [SerializeField] private Keypad keypad; //Clavier
    public int nombre; // Nombre obtenu par le joueur lorsqu'il presse un bouton sur le clavier.

    /// <summary>
    /// Appelée lorsqu'un joueur presse ce bouton du clavier.
    /// </summary>
    public void BoutonPresse()
    {
        // Vérifie si la réponse n'a pas déjà été trouvée avant d'ajouter ce nombre au clavier.
        //Si la réponse a déjà été trouvée, le joueur ne peut plus interagir avec les boutons
        if (!keypad.IsReponseTrouvee())
        {
            keypad.Nombre(nombre); // Ajoute le nombre associé au bouton au texte du clavier.
        }
    }

    /// <summary>
    /// Appelée lorsque le joueur interagit avec le bouton droit de la souris.
    /// </summary>
    public void InteractionDroite(Transform Joueur)
    {
        // Aucune action pour l'instant.
    }

    /// <summary>
    /// Appelée lorsque le joueur interagit avec le bouton gauche de la souris.
    /// </summary>
    public void InteractionGauche(Transform Joueur)
    {
        BoutonPresse(); 
    }
}
