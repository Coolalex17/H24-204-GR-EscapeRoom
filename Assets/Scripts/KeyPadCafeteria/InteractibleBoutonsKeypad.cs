using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet � un joueur d'interagir avec des boutons d'un clavier.
/// </summary>
public class InteractibleBoutonsKeypad : MonoBehaviour, Interactible
{
    [SerializeField] private Keypad keypad; //Clavier
    public int nombre; // Nombre obtenu par le joueur lorsqu'il presse un bouton sur le clavier.

    /// <summary>
    /// Appel�e lorsqu'un joueur presse ce bouton du clavier.
    /// </summary>
    public void BoutonPresse()
    {
        // V�rifie si la r�ponse n'a pas d�j� �t� trouv�e avant d'ajouter ce nombre au clavier.
        //Si la r�ponse a d�j� �t� trouv�e, le joueur ne peut plus interagir avec les boutons
        if (!keypad.IsReponseTrouvee())
        {
            keypad.Nombre(nombre); // Ajoute le nombre associ� au bouton au texte du clavier.
        }
    }

    /// <summary>
    /// Appel�e lorsque le joueur interagit avec le bouton droit de la souris.
    /// </summary>
    public void InteractionDroite(Transform Joueur)
    {
        // Aucune action pour l'instant.
    }

    /// <summary>
    /// Appel�e lorsque le joueur interagit avec le bouton gauche de la souris.
    /// </summary>
    public void InteractionGauche(Transform Joueur)
    {
        BoutonPresse(); 
    }
}
