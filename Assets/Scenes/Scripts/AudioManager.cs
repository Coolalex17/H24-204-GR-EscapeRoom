using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    /// <summary>
    /// volumePrincipal : volume de tout les sons du jeu
    /// volumeMusique : volume de la musique
    /// volumeSons : volume des sons du jeu (ce que le joueur entend comme si c'etait placé loin de lui)
    /// </summary>
    private static float volumePrincipal = 100;
    private static float volumeMusique = 100;
    private static float volumeSons = 100;

    /// <summary>
    /// Peut modifier le volume de tout les bruits du jeu, la valeur ne peut pas être négatif et de maximum 100
    /// </summary>
    /// <param name="volume"> Nouvelle valeur du volume principal </param>
    public static void modifierVolumePrincipal(float volume) {
        volumePrincipal = Math.Min(Math.Max(volume,0),100 );
    }

    /// <summary>
    /// Peut modifier le volume de tout les musiques du jeu, la valeur ne peut pas être négatif et de maximum 100
    /// </summary>
    /// <param name="volume"> Nouvelle valeur du volume de la Musique </param>
    public static void modifierVolumeMusique(float volume) {
        volumeMusique = Math.Min(Math.Max(volume, 0), 100);
    }

    /// <summary>
    ///  Peut modifier le volume de tout les effets sonores du jeu, la valeur ne peut pas être négatif et de maximum 100
    /// </summary>
    /// <param name="volume">Nouvelle valeur du volume des effets sonores </param>
    public static void modifierVolumeSons(float volume) {
        volumeSons = Math.Min(Math.Max(volume, 0), 100);
    }

    /// <summary>
    /// Demare leffet sonore selon le volume qui a ete choisi
    /// </summary>
    /// <param name="audioSource">Source audio qui emmet le son </param>
    public static void jouerEffetSonore(AudioSource audioSource,float volume) {
        audioSource.volume = volumeSons / 100 * volumePrincipal / 100 * volume;
        audioSource.Play();
    }



    /// <summary>
    /// Demare la musique au volume qui a ete choisi
    /// </summary>
    /// <param name="audioSource">Source audio qui emmet la musique</param>
    public static void jouerMusique(AudioSource audioSource,float volume) {
        audioSource.volume = volumeMusique / 100 * volumePrincipal / 100 * volume;
        audioSource.Play();
    }

}
