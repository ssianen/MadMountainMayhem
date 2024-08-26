using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]

    public AudioClip growing;
    public AudioClip shrinking;

    public AudioClip chopping; //add later

    public AudioClip collecting; //add later

    public void Start(){
        // musicSource.clip = background; //add later
        // musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }
    
}
