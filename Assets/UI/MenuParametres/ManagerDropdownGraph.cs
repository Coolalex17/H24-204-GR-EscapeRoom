using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManagerDropdown : MonoBehaviour
{
    public Dropdown myDropdown;

void OnDisable()
{
    // Check if myDropdown is not null before accessing its value
    if (myDropdown != null)
    {
        // Save the selected index of the dropdown before changing scenes
        PlayerPrefs.SetInt("DropdownIndex", myDropdown.value);
    }
}

void Start()
{
    // Check if myDropdown is not null before accessing its value
    if (myDropdown != null)
    {
        // Load the selected index of the dropdown when the scene starts
        int dropdownIndex = PlayerPrefs.GetInt("DropdownIndex", 0);
        myDropdown.value = dropdownIndex;

        // If you want to reset the dropdown state, uncomment the next line
        // PlayerPrefs.DeleteKey("DropdownIndex");
    }
    }

}
