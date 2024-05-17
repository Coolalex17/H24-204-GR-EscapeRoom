using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// G�re la s�lection de r�solution dans un dropdown.
/// </summary>
public class ManagerDropdownResolution : MonoBehaviour
{
    public Dropdown resolutionDropdown; // Dropdown pour choisir la r�solution.

    void Start()
    {
        // Ajoute un �couteur d'�v�nement pour d�tecter les changements de r�solution.
        resolutionDropdown.onValueChanged.AddListener(ResolutionModifiee);

        // Charge l'index de r�solution pr�c�demment enregistr�.
        int indexEnregistre = PlayerPrefs.GetInt("ResolutionIndex", 0);
        resolutionDropdown.value = indexEnregistre;
    }

    /// <summary>
    /// Appel�e lorsque la r�solution est modifi�e dans le dropdown.
    /// </summary>
    /// <param name="resolutionIndex">Index de la r�solution s�lectionn�e.</param>
    private void ResolutionModifiee(int resolutionIndex)
    {
        // Enregistre l'index de la r�solution s�lectionn�e.
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);

        // R�cup�re l'option de r�solution s�lectionn�e dans le dropdown.
        string resolutionOption = resolutionDropdown.options[resolutionIndex].text;

        // Extrait la largeur et la hauteur de la r�solution � partir de l'option choisie par le joueur.
        string[] resolutionParties = resolutionOption.Split('x');
        int largeur = int.Parse(resolutionParties[0]);
        int hauteur = int.Parse(resolutionParties[1]);

        // Change la r�solution en fonction de la s�lection dans le dropdown.
        Screen.SetResolution(largeur, hauteur, true);
    }

    /// <summary>
    /// Sauvegarde l'index de r�solution s�lectionn� avant de changer de sc�ne.
    /// </summary>
    private void SauvegarderResolutionIndex()
    {
        PlayerPrefs.Save();
    }
}
