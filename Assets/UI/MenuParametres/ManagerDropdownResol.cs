using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerDropdownResolution : MonoBehaviour //ChatGPT

{

    public Dropdown resolutionDropdown;
    void Start()
    {
        // Subscribe to the OnValueChanged event of the dropdown
        resolutionDropdown.onValueChanged.AddListener(ResolutionModifiee);

        // Load the previously saved resolution index
        int indexEnregistre = PlayerPrefs.GetInt("ResolutionIndex", 0);
        resolutionDropdown.value = indexEnregistre;
    }

    private void ResolutionModifiee(int resolutionIndex)
    {
        // Save the selected resolution index
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);

        // Get the selected resolution option from the dropdown
        string resolutionOption = resolutionDropdown.options[resolutionIndex].text;

        // Parse the resolution from the option
        string[] resolutionParties = resolutionOption.Split('x');
        int largeur = int.Parse(resolutionParties[0]);
        int hauteur = int.Parse(resolutionParties[1]);

        // Change resolution based on dropdown selection
        Screen.SetResolution(largeur, hauteur, true);
    }

    private void SauvegarderResolutionIndex()
    {
        // Save the selected resolution index before changing scenes
        PlayerPrefs.Save();
    }
}
