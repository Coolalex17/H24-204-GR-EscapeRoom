using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Contr�le le fonctionnement d'un clavier num�rique pour ouvrir un r�frig�rateur et un coffre.
/// </summary>
public class Keypad : MonoBehaviour //https://www.youtube.com/watch?v=TO0g5jyjpYU
{
    public string reponse; // La r�ponse � entrer dans le clavier (code tap�).
    [SerializeField] private Text texteAAfficherSurKeypad; // Texte affich� sur le clavier.
    [SerializeField] private Animator refregirateur; // Animator pour le r�frig�rateur.
    [SerializeField] private Animator coffre; // Animator pour le coffre.
    private bool reponseTrouvee = false; // Indique si la r�ponse (code tap�) a �t� trouv�e.

    /// <summary>
    /// Ajoute au texte � afficher sur le clavier le nombre tap� par le joueur.
    /// </summary>
    /// <param name="nombre">Le nombre � ajouter (nombre tap� du clavier par le joueur).</param>
    public void Nombre(int nombre)
    {
        if (texteAAfficherSurKeypad.text == "Incorrect" || texteAAfficherSurKeypad.text == "Correct")
        {
            texteAAfficherSurKeypad.text = "";
        }
        texteAAfficherSurKeypad.text += nombre.ToString();
    }

    /// <summary>
    /// Ex�cute la s�quence de nombres entr�e par le joueur et v�rifie si elle est correcte.
    /// </summary>
    public void Executer()
    {
        if (texteAAfficherSurKeypad.text == reponse)
        {
            // On affiche Correct sur le clavier
            texteAAfficherSurKeypad.text = "Correct";
            //On ouvre la porte du r�fr�girateur
            refregirateur.SetBool("Ouvert", true);
            //On ouvre la porte du coffre
            coffre.Play("TreasureChest_OPEN", 0);
            reponseTrouvee = true;
            StartCoroutine("Stop");
        }
        else
        {
            // On affiche Incorrect sur le clavier, car le bon code n'a pas �t� trouv�
            texteAAfficherSurKeypad.text = "Incorrect";
        }
    }

    /// <summary>
    /// D�sactive l'ouverture de la porte du r�frig�rateur apr�s un court d�lai
    /// pour l'emp�cher de s'ouvrir et se fermer continuellement.
    /// </summary>
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.5f);
        refregirateur.SetBool("Ouvert", false);
        refregirateur.enabled = false;
    }

    /// <summary>
    /// Indique si la r�ponse a �t� trouv�e avec succ�s.
    /// </summary>
    /// <returns>Vrai si la r�ponse a �t� trouv�e, sinon faux.</returns>
    public bool IsReponseTrouvee()
    {
        return reponseTrouvee;
    }
}
