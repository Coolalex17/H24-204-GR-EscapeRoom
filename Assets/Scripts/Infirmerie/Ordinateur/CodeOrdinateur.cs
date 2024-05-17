using UnityEngine;
using UnityEngine.UI; // Utilisé pour les composants UI standard
using TMPro; // Utilisé pour les composants TextMeshPro

/// <summary>
/// Cette classe gère l'entrée et la vérification du code sur un ordinateur.
/// </summary>
public class CodeOrdinateur : MonoBehaviour
{

    private const string REPONSE = "221"; // La réponse correcte pour déverrouiller l'ordinateur.

    
    [SerializeField] private Text messageAAfficherSurOrdi; // Référence au Text pour afficher les messages sur l'ordinateur, assignée dans l'inspecteur.

    private bool reponseTrouvee = false; // Indique si la bonne réponse a été trouvée.

    /// <summary>
    /// Ajoute un nombre au message affiché sur l'ordinateur.
    /// </summary>
    /// <param name="nombre">Le nombre à ajouter entré par le joueur.</param>
    public void Nombre(int nombre)
    {
        // Si le message affiché est "Incorrect" ou "Correct", le réinitialiser.
        if (messageAAfficherSurOrdi.text == "Incorrect" || messageAAfficherSurOrdi.text == "Globe à trouver")
        {
            messageAAfficherSurOrdi.text = "";
        }

        // Ajouter le nombre au texte affiché.
        messageAAfficherSurOrdi.text += nombre.ToString();
    }

    /// <summary>
    /// Vérifie si le message affiché correspond à la réponse correcte. Si c'est le cas, une clé bleue est donnée au jouer.
    /// </summary>
    public void Execute()
    {
        if (messageAAfficherSurOrdi.text == REPONSE)
        {
            messageAAfficherSurOrdi.text = "Correct"; // Si le bon code est rentré, on affiche correcte sur l'ordi
            PreferencesJoueur.GetSavedInventaire().Add(Inventaire.Items.CLEE_BLEU);
            reponseTrouvee = true;
        }
        else
        {
            messageAAfficherSurOrdi.text = "Incorrect";
        }
    }

    /// <summary>
    /// Indique si la bonne réponse a été trouvée.
    /// </summary>
    /// <returns>Vrai si la bonne réponse a été trouvée, sinon faux.</returns>
    public bool IsReponseTrouvee()
    {
        return reponseTrouvee;
    }
}
