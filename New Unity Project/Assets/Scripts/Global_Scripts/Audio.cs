using UnityEngine;
using System;

[Serializable]
public class Audio{
    [SerializeField] private string name;
    [SerializeField] private AudioClip value;

    public Audio(string name, AudioClip value)
    {
        this.name = name;
        this.value = value;
    }

    public bool CheckName(string findingName, out AudioClip audio){
        audio = null;
        if(findingName == name){
            audio = value;
            return true;
        }
        return false;
    }
}

