using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSound : MonoBehaviour
{
    private AudioSource _audio;
    void Start()
    {
         AudioClip clip;
         AudioManager.GetAudioSource("BGMusic1",out clip);
        _audio.GetComponent<AudioSource>();
        _audio.clip=clip;
        _audio.Play();
    }

    
}
