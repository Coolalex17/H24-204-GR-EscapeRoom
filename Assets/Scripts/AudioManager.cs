using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static float volumePrincipal = 100;
    private static float volumeMusique = 100;
    private static float volumeSons = 100;

    public static void modifierVolumePrincipal(float volume) {
        volumePrincipal = volume;
    }
    public static void modifierVolumeMusique(float volume) {
        volumeMusique = volume;
    }
    public static void modifierVolumeSons(float volume) {
        volumeSons = volume;
    }

    public static void jouerEffetSonore(AudioSource audioSource) {
        audioSource.volume = volumeSons/100 * volumePrincipal/100;
        audioSource.Play();

    }
    public static void jouerMusique(AudioSource audioSource) {
        audioSource.volume = volumeMusique / 100 * volumePrincipal / 100;
        audioSource.Play();



    }

}
