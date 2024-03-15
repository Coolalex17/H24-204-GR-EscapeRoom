using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerMusique : MonoBehaviour
{

    
    private AudioSource audioSource;
    public Slider musiqueSlider;
    public GameObject objetMusique;

    private float musiqueVolume = 1f;

  
    private void Start()
    {
        objetMusique = GameObject.FindWithTag("GameMusique");
        audioSource = objetMusique.GetComponent<AudioSource>();

        musiqueVolume = PlayerPrefs.GetFloat("volume");
        audioSource.volume = musiqueVolume;
        musiqueSlider.value = musiqueVolume;
    }
    void Update()
    {
        audioSource.volume = musiqueVolume;
        PlayerPrefs.SetFloat("volume", musiqueVolume);
    }

    public void UpdateVolume(float volume)
    {
        musiqueVolume = volume;
    }



}