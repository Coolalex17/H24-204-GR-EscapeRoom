using UnityEngine;
using UnityEngine.UI; // Utilis� pour les composants UI standard
using TMPro; // Utilis� pour les composants TextMeshPro

/// <summary>
/// Cette classe g�re l'entr�e et la v�rification du code sur un ordinateur.
/// </summary>
public class CodeOrdinateur : MonoBehaviour
{

    private const string REPONSE = "221"; // La r�ponse correcte pour d�verrouiller l'ordinateur.

    
    [SerializeField] private Text messageAAfficherSurOrdi; // R�f�rence au Text pour afficher les messages sur l'ordinateur, assign�e dans l'inspecteur.

    private bool reponseTrouvee = false; // Indique si la bonne r�ponse a �t� trouv�e.

    /// <summary>
    /// Ajoute un nombre au message affich� sur l'ordinateur.
    /// </summary>
    /// <param name="nombre">Le nombre � ajouter entr� par le joueur.</param>
    public void Nombre(int nombre)
    {
        // Si le message affich� est "Incorrect" ou "Correct", le r�initialiser.
        if (messageAAfficherSurOrdi.text == "Incorrect" || messageAAfficherSurOrdi.text == "Globe � trouver")
        {
            messageAAfficherSurOrdi.text = "";
        }

        // Ajouter le nombre au texte affich�.
        messageAAfficherSurOrdi.text += nombre.ToString();
    }

    /// <summary>
    /// V�rifie si le message affich� correspond � la r�ponse correcte. Si c'est le cas, une cl� bleue est donn�e au jouer.
    /// </summary>
    public void Execute()
    {
        if (messageAAfficherSurOrdi.text == REPONSE)
        {
            messageAAfficherSurOrdi.text = "Correct"; // Si le bon code est rentr�, on affiche correcte sur l'ordi
            PreferencesJoueur.GetSavedInventaire().Add(Inventaire.Items.CLEE_BLEU);
            reponseTrouvee = true;
        }
        else
        {
            messageAAfficherSurOrdi.text = "Incorrect";
        }
    }

    /// <summary>
    /// Indique si la bonne r�ponse a �t� trouv�e.
    /// </summary>
    /// <returns>Vrai si la bonne r�ponse a �t� trouv�e, sinon faux.</returns>
    public bool IsReponseTrouvee()
    {
        return reponseTrouvee;
    }
}
