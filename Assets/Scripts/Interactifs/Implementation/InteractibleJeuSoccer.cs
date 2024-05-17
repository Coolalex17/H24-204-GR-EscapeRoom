using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractibleJeuSoccer : MonoBehaviour, Interactible
{
    public void InteractionDroite(Transform Joueur) {
        Debug.Log("Rien");
    }
    /// <summary>
    /// Debute la scene du jeu de soccer
    /// </summary>
    /// <param name="Joueur"></param>
    public void InteractionGauche(Transform Joueur) {
        if(PreferencesJoueur.getFiniJeuSoccer()) {
            return;
        }
        SceneManager.LoadScene("3emJeu");
    }

}