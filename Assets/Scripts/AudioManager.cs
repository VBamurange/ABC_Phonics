using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //public static AudioManager instance;
    public AudioSource audioSource;


    void Start()
    {
         audioSource = GetComponent<AudioSource>();   
    }

    public void PlayAudio()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
