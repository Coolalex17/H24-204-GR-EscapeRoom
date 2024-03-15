using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Toggle myCheckbox;

    void OnDisable()
    {
        // Save the checkbox state before changing scenes
        PlayerPrefs.SetInt("CheckboxState", myCheckbox.isOn ? 1 : 0);
    }
    void Start()
    {
        // Load the checkbox state when the scene starts
        int checkboxState = PlayerPrefs.GetInt("CheckboxState", 0);
        myCheckbox.isOn = checkboxState == 1;

        // If you want to reset the checkbox state, uncomment the next line
        // PlayerPrefs.DeleteKey("CheckboxState");
    }
}
