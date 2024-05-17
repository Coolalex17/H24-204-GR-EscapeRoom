using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet à un joueur d'interagir avec un bouton "Exécuter" d'un clavier.
/// </summary>
public class InteractibleKeypadExecuter : MonoBehaviour, Interactible
{
    [SerializeField] private Keypad keypad; // Clavier.

    /// <summary>
    /// Appelée lorsqu'un joueur presse le bouton "Exécuter" du clavier.
    /// </summary>
    public void BoutonPresse()
    {
        // Vérifie si la réponse n'a pas déjà été trouvée avant d'exécuter la séquence.
        //Sinon, le joueur ne peut pas interagir avec le bouton Exécuter
        if (!keypad.IsReponseTrouvee())
        {
            keypad.Executer(); // Exécute le code tapé par le joueur pour vérifier s'il a la bonne réponse.
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
