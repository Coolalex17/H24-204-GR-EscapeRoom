using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe pour g�rer l'interaction de l'objet interactif contenant le jeu des drapeaux.
/// </summary>
public class InteractibleJeuDrapeau : MonoBehaviour, Interactible
{

    public void InteractionDroite(Transform Joueur)
    {
        // Actuellement pas utilis�e
    }

    //M�thode appel�e lorsque le joueur interagit avec l'objet avec un clic gauche.
    public void InteractionGauche(Transform Joueur)
    {
        // V�rifie si le jeu des drapeaux est d�j� termin�
        // Si c'est le cas, le joueur ne peut pas y acc�der.
        if (PreferencesJoueur.getFiniJeuDrapeaux())
        {
            return; // Si le jeu est termin�, ne fait rien
        }

        // D�verrouille le curseur de la souris pour permettre son mouvement
        Cursor.lockState = CursorLockMode.Confined;

        // Charge la sc�ne du jeu des drapeaux
        SceneManager.LoadScene("JeuDrapeau");
    }
}
