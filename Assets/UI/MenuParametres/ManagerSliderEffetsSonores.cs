using UnityEngine;
using UnityEngine.UI;

public class ManagerEffetsSonores : MonoBehaviour
{
    public Slider effetsSlider;
    public AudioSource audioSource;

    void Start()
    {
        
        float volumeEnregistre = PlayerPrefs.GetFloat("EffetsSonores", 1f);
        effetsSlider.value = volumeEnregistre;
        MettreAJourVolume(volumeEnregistre);
        effetsSlider.onValueChanged.AddListener(MettreAJourVolume);
    }

   
    void MettreAJourVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("EffetsSonores", volume);
        PlayerPrefs.Save();
    }
}


