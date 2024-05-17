using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gère la sélection de résolution dans un dropdown.
/// </summary>
public class ManagerDropdownResolution : MonoBehaviour
{
    public Dropdown resolutionDropdown; // Dropdown pour choisir la résolution.

    void Start()
    {
        // Ajoute un écouteur d'événement pour détecter les changements de résolution.
        resolutionDropdown.onValueChanged.AddListener(ResolutionModifiee);

        // Charge l'index de résolution précédemment enregistré.
        int indexEnregistre = PlayerPrefs.GetInt("ResolutionIndex", 0);
        resolutionDropdown.value = indexEnregistre;
    }

    /// <summary>
    /// Appelée lorsque la résolution est modifiée dans le dropdown.
    /// </summary>
    /// <param name="resolutionIndex">Index de la résolution sélectionnée.</param>
    private void ResolutionModifiee(int resolutionIndex)
    {
        // Enregistre l'index de la résolution sélectionnée.
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);

        // Récupère l'option de résolution sélectionnée dans le dropdown.
        string resolutionOption = resolutionDropdown.options[resolutionIndex].text;

        // Extrait la largeur et la hauteur de la résolution à partir de l'option choisie par le joueur.
        string[] resolutionParties = resolutionOption.Split('x');
        int largeur = int.Parse(resolutionParties[0]);
        int hauteur = int.Parse(resolutionParties[1]);

        // Change la résolution en fonction de la sélection dans le dropdown.
        Screen.SetResolution(largeur, hauteur, true);
    }

    /// <summary>
    /// Sauvegarde l'index de résolution sélectionné avant de changer de scène.
    /// </summary>
    private void SauvegarderResolutionIndex()
    {
        PlayerPrefs.Save();
    }
}
