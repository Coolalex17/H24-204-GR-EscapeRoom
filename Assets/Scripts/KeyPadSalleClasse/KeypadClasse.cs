using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Contrôle le fonctionnement d'un clavier numérique pour obtenir une clé.
/// </summary>
public class KeypadClasse : MonoBehaviour //https://www.youtube.com/watch?v=TO0g5jyjpYU
{
    public string reponse; // La réponse à entrer dans le clavier (code tapé).
    [SerializeField] private Text texteAAfficherSurKeypad; // Texte affiché sur le clavier.
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
    /// Exécute la séquence de nombres entrée par le joueur et vérifie si elle est correcte. Si elle l'est, le joueur reçoit une clé.
    /// </summary>
    public void Executer()
    {
        if (texteAAfficherSurKeypad.text == reponse)
        {
            if (texteAAfficherSurKeypad.text == "814") {
                PreferencesJoueur.GetSavedInventaire().Add(Inventaire.Items.CLEE_BLANCHE);
            }
            texteAAfficherSurKeypad.text = "Correct";
            reponseTrouvee = true;

        }
        else
        {
            // On affiche Incorrect sur le clavier, car le bon code n'a pas été trouvé
            texteAAfficherSurKeypad.text = "Incorrect";
        }
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
