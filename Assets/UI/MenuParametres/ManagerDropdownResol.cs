using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resolutionManagerà : MonoBehaviour

{

    public Dropdown resolutionDropdown;
    void Start()
    {
        // Subscribe to the OnValueChanged event of the dropdown
        resolutionDropdown.onValueChanged.AddListener(OnResolutionDropdownValueChanged);

        // Load the previously saved resolution index
        int savedIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
        resolutionDropdown.value = savedIndex;
    }

    void OnResolutionDropdownValueChanged(int resolutionIndex)
    {
        // Save the selected resolution index
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);

        // Get the selected resolution option from the dropdown
        string resolutionOption = resolutionDropdown.options[resolutionIndex].text;

        // Parse the resolution from the option
        string[] resolutionParts = resolutionOption.Split('x');
        int width = int.Parse(resolutionParts[0]);
        int height = int.Parse(resolutionParts[1]);

        // Change resolution based on dropdown selection
        Screen.SetResolution(width, height, true);
    }

    void OnDisable()
    {
        // Save the selected resolution index before changing scenes
        PlayerPrefs.Save();
    }
}
