using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    private void Start() => instance = this;
    [SerializeField] private Audio[] AudioSoures;

    public static bool GetAudioSource(string name, out AudioSource value) {
        value = null;
        foreach (var audio in instance.AudioSoures)
        {            
            if(audio.CheckName(name, out var result)){
                value = result;
                return true;
            }
        }
        return false;
    }
}

