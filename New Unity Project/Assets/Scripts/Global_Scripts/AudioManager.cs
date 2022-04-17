using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    private void Start() => instance = this;
    [SerializeField] private Audio[] AudioClips;

    public static bool GetAudioSource(string name, out AudioClip value) {
        value = null;
        foreach (var audio in instance.AudioClips)
        {            
            if(audio.CheckName(name, out var result)){
                value = result;
                return true;
            }
        }
        return false;
    }
}

