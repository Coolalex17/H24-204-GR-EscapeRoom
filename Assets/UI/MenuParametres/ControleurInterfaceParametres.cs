using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuParametres : MonoBehaviour
{

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
}
