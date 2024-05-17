using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Contrôle le fonctionnement d'un clavier numérique pour ouvrir un réfrigérateur et un coffre.
/// </summary>
public class Keypad : MonoBehaviour //https://www.youtube.com/watch?v=TO0g5jyjpYU
{
    public string reponse; // La réponse à entrer dans le clavier (code tapé).
    [SerializeField] private Text texteAAfficherSurKeypad; // Texte affiché sur le clavier.
    [SerializeField] private Animator refregirateur; // Animator pour le réfrigérateur.
    [SerializeField] private Animator coffre; // Animator pour le coffre.
    private bool reponseTrouvee = false; // Indique si la réponse (code tapé) a été trouvée.

    /// <summary>
    /// Ajoute au texte à afficher sur le clavier le nombre tapé par le joueur.
    /// </summary>
    /// <param name="nombre">Le nombre à ajouter (nombre tapé du clavier par le joueur).</param>
    public void Nombre(int nombre)
    {
        if (texteAAfficherSurKeypad.text == "Incorrect" || texteAAfficherSurKeypad.text == "Correct")
        {
            texteAAfficherSurKeypad.text = "";
        }
        texteAAfficherSurKeypad.text += nombre.ToString();
    }

    /// <summary>
    /// Exécute la séquence de nombres entrée par le joueur et vérifie si elle est correcte.
    /// </summary>
    public void Executer()
    {
        if (texteAAfficherSurKeypad.text == reponse)
        {
            if (texteAAfficherSurKeypad.text == "6878")
            {
                PreferencesJoueur.GetSavedInventaire().Add(Inventaire.Items.CLEE_NOIR);
            }
            // On affiche Correct sur le clavier
            texteAAfficherSurKeypad.text = "Correct";
            //On ouvre la porte du réfrégirateur
            refregirateur.SetBool("Ouvert", true);
            //On ouvre la porte du coffre
            coffre.Play("TreasureChest_OPEN", 0);
            reponseTrouvee = true;
            StartCoroutine("Stop");
        }
        else
        {
            // On affiche Incorrect sur le clavier, car le bon code n'a pas été trouvé
            texteAAfficherSurKeypad.text = "Incorrect";
        }
    }

    /// <summary>
    /// Désactive l'ouverture de la porte du réfrigérateur après un court délai
    /// pour l'empêcher de s'ouvrir et se fermer continuellement.
    /// </summary>
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.3f);
        refregirateur.SetBool("Ouvert", false);
        refregirateur.enabled = false;
    }

    /// <summary>
    /// Indique si la réponse a été trouvée avec succès.
    /// </summary>
    /// <returns>Vrai si la réponse a été trouvée, sinon faux.</returns>
    public bool IsReponseTrouvee()
    {
        return reponseTrouvee;
    }
}
