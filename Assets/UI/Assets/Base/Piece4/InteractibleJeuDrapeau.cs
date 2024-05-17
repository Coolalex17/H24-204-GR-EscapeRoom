using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe pour gérer l'interaction de l'objet interactif contenant le jeu des drapeaux.
/// </summary>
public class InteractibleJeuDrapeau : MonoBehaviour, Interactible
{

    public void InteractionDroite(Transform Joueur)
    {
        // Actuellement pas utilisée
    }

    //Méthode appelée lorsque le joueur interagit avec l'objet avec un clic gauche.
    public void InteractionGauche(Transform Joueur)
    {
        // Vérifie si le jeu des drapeaux est déjà terminé
        // Si c'est le cas, le joueur ne peut pas y accéder.
        if (PreferencesJoueur.getFiniJeuDrapeaux())
        {
            return; // Si le jeu est terminé, ne fait rien
        }

        // Déverrouille le curseur de la souris pour permettre son mouvement
        Cursor.lockState = CursorLockMode.Confined;

        // Charge la scène du jeu des drapeaux
        SceneManager.LoadScene("JeuDrapeau");
    }
}
