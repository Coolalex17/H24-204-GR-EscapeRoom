using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe pour gérer les interactions avec l'objet interactif contenant le jeu de calcul.
/// Implémente l'interface Interactible.
/// </summary>
public class InteractibleJeuCalcul : MonoBehaviour, Interactible
{
    
    public void InteractionDroite(Transform Joueur)
    {
        // Fonctionnalité pas utile présentement.
    }

    /// <summary>
    /// Gère l'interaction par clic gauche. Charge la scène du jeu de calcul si le joueur n'a pas déjà terminé le jeu.
    /// </summary>
    /// <param name="Joueur">Transform du joueur.</param>
    public void InteractionGauche(Transform Joueur)
    {
        // Vérifie si le joueur a déjà terminé le jeu de calcul.
        if (PreferencesJoueur.getFiniJeuCalcul())
        {
            return;
        }

        // Déverrouille le curseur et le rend visible.
        Cursor.lockState = CursorLockMode.Confined;

        // Charge la scène du jeu de calcul.
        SceneManager.LoadScene("JeuMath");
    }

    /// <summary>
    /// Quitte la scène actuelle et charge la scène de jeu principale.
    /// </summary>
    public void Quitter()
    {
        // Charge la scène principale de l'école.
        SceneManager.LoadScene("SceneJeuV2");
    }
}

