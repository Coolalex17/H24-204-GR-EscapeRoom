using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// G�re les param�tres de la musique dans le jeu.
/// </summary>
public class ManagerMusique : MonoBehaviour
{
    private AudioSource audioSource; // Source audio utilis�e pour jouer la musique.
    public Slider musiqueSlider; // Slider utilis� pour r�gler le volume de la musique.
    public GameObject objetMusique; // GameObject contenant la musique.
    private float musiqueVolume = 1f; // Volume de la musique

    private void Start()
    {
        // Recherche l'objet contenant la musique par son tag.
        objetMusique = GameObject.FindWithTag("GameMusique");

        // R�cup�re le composant AudioSource de l'objet de la musique.
        audioSource = objetMusique.GetComponent<AudioSource>();

        // R�cup�re le volume de la musique depuis les pr�f�rences du joueur.
        musiqueVolume = PlayerPrefs.GetFloat("volume");

        // Applique le volume r�cup�r� � l'audio source et au slider de la musique.
        audioSource.volume = musiqueVolume;
        musiqueSlider.value = musiqueVolume;
    }

    /// <summary>
    /// Met � jour le volume de la musique de l'audioSource et le sauvegarde dans les pr�f�rences du joueur.
    /// </summary>
    private void SauvegarderMusique()
    {
        audioSource.volume = musiqueVolume; // Met � jour le volume de la musique.
        PlayerPrefs.SetFloat("volume", musiqueVolume); // Sauvegarde le volume dans les pr�f�rences du joueur.
    }

    /// <summary>
    /// Met � jour le volume de la musique en fonction de la valeur du Slider.
    /// </summary>
    /// <param name="volume">Nouvelle valeur de volume.</param>
    private void MettreAJourVolume(float volume)
    {
        musiqueVolume = volume; 
    }
}
