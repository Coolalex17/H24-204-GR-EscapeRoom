using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gère le volume des effets sonores dans le jeu.
/// </summary>
public class ManagerEffetsSonores : MonoBehaviour
{
    public Slider effetsSlider; // Slider pour régler le volume des effets sonores.
    public AudioSource audioSource; // Source audio des effets sonores.

    void Start()
    {
        // Récupère le volume des effets sonores depuis les préférences du joueur.
        float volumeEnregistre = PlayerPrefs.GetFloat("EffetsSonores", 1f);

        // Initialise le Slider avec le volume enregistré.
        effetsSlider.value = volumeEnregistre;

        // Applique le volume enregistré.
        MettreAJourVolume(volumeEnregistre);

        // Ajoute un écouteur d'événement pour détecter les changements de volume.
        effetsSlider.onValueChanged.AddListener(MettreAJourVolume);
    }

    /// <summary>
    /// Met à jour le volume des effets sonores.
    /// </summary>
    /// <param name="volume">Nouvelle valeur de volume.</param>
    private void MettreAJourVolume(float volume)
    {
        // Met à jour le volume des effets sonores.
        audioSource.volume = volume;
        // Enregistre le volume dans les préférences du joueur.
        PlayerPrefs.SetFloat("EffetsSonores", volume);
        // Sauvegarde les préférences.
        PlayerPrefs.Save();
    }
}

