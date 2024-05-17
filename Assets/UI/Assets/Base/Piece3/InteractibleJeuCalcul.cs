using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe pour g�rer les interactions avec l'objet interactif contenant le jeu de calcul.
/// Impl�mente l'interface Interactible.
/// </summary>
public class InteractibleJeuCalcul : MonoBehaviour, Interactible
{
    
    public void InteractionDroite(Transform Joueur)
    {
        // Fonctionnalit� pas utile pr�sentement.
    }

    /// <summary>
    /// G�re l'interaction par clic gauche. Charge la sc�ne du jeu de calcul si le joueur n'a pas d�j� termin� le jeu.
    /// </summary>
    /// <param name="Joueur">Transform du joueur.</param>
    public void InteractionGauche(Transform Joueur)
    {
        // V�rifie si le joueur a d�j� termin� le jeu de calcul.
        if (PreferencesJoueur.getFiniJeuCalcul())
        {
            return;
        }

        // D�verrouille le curseur et le rend visible.
        Cursor.lockState = CursorLockMode.Confined;

        // Charge la sc�ne du jeu de calcul.
        SceneManager.LoadScene("JeuMath");
    }

    /// <summary>
    /// Quitte la sc�ne actuelle et charge la sc�ne de jeu principale.
    /// </summary>
    public void Quitter()
    {
        // Charge la sc�ne principale de l'�cole.
        SceneManager.LoadScene("SceneJeuV2");
    }
}

