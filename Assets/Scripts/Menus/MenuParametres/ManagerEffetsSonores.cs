using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// G�re le volume des effets sonores dans le jeu.
/// </summary>
public class ManagerEffetsSonores : MonoBehaviour
{
    public Slider effetsSlider; // Slider pour r�gler le volume des effets sonores.
    public AudioSource audioSource; // Source audio des effets sonores.

    void Start()
    {
        // R�cup�re le volume des effets sonores depuis les pr�f�rences du joueur.
        float volumeEnregistre = PlayerPrefs.GetFloat("EffetsSonores", 1f);

        // Initialise le Slider avec le volume enregistr�.
        effetsSlider.value = volumeEnregistre;

        // Applique le volume enregistr�.
        MettreAJourVolume(volumeEnregistre);

        // Ajoute un �couteur d'�v�nement pour d�tecter les changements de volume.
        effetsSlider.onValueChanged.AddListener(MettreAJourVolume);
    }

    /// <summary>
    /// Met � jour le volume des effets sonores.
    /// </summary>
    /// <param name="volume">Nouvelle valeur de volume.</param>
    private void MettreAJourVolume(float volume)
    {
        // Met � jour le volume des effets sonores.
        audioSource.volume = volume;
        // Enregistre le volume dans les pr�f�rences du joueur.
        PlayerPrefs.SetFloat("EffetsSonores", volume);
        // Sauvegarde les pr�f�rences.
        PlayerPrefs.Save();
    }
}

