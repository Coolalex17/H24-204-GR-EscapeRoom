using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MenuParametres : MonoBehaviour
{

    public Slider masterVol, musicVol, effetsVol;
    public AudioMixer mainAudioMixer;
    public void ChangeMusiqueVolume()
    {
        mainAudioMixer.SetFloat("MusiqueVol", musicVol.value);
    }
    public void ChangeMusiqueEffets()
    {
        mainAudioMixer.SetFloat("EffetsVol", effetsVol.value);
    }


    public Dropdown resolutionDropdown;
    public static MenuParametres Instance;


    Resolution[] resolutions;
    void Start()
    {
        // Subscribe to the OnValueChanged event of the dropdown
        resolutionDropdown.onValueChanged.AddListener(OnResolutionDropdownValueChanged);
    }

    void OnResolutionDropdownValueChanged(int resolutionIndex)
    {
        // Get the selected resolution option from the dropdown
        string resolutionOption = resolutionDropdown.options[resolutionIndex].text;

        // Parse the resolution from the option
        string[] resolutionParts = resolutionOption.Split('x');
        int width = int.Parse(resolutionParts[0]);
        int height = int.Parse(resolutionParts[1]);

        // Change resolution based on dropdown selection
        Screen.SetResolution(width, height, true);
    }

    public void BtnQuitter()
    {
        Application.Quit();
    }

    public void BtnRetour()
    {
       
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }

    public AudioMixer audioMixer;
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void setQualite(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

   public void setPleinEcran(bool pleinEcran)
    {
        Screen.fullScreen = pleinEcran;
    }


}
