using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet � un joueur d'interagir avec un bouton "Ex�cuter" d'un clavier.
/// </summary>
public class InteractibleKeypadExecuter : MonoBehaviour, Interactible
{
    [SerializeField] private Keypad keypad; // Clavier.

    /// <summary>
    /// Appel�e lorsqu'un joueur presse le bouton "Ex�cuter" du clavier.
    /// </summary>
    public void BoutonPresse()
    {
        // V�rifie si la r�ponse n'a pas d�j� �t� trouv�e avant d'ex�cuter la s�quence.
        //Sinon, le joueur ne peut pas interagir avec le bouton Ex�cuter
        if (!keypad.IsReponseTrouvee())
        {
            keypad.Executer(); // Ex�cute le code tap� par le joueur pour v�rifier s'il a la bonne r�ponse.
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
