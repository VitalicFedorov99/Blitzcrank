using UnityEngine;
using System;

[Serializable]
public class Audio{
    [SerializeField] private string name;
    [SerializeField] private AudioSource value;

    public Audio(string name, AudioSource value)
    {
        this.name = name;
        this.value = value;
    }

    public bool CheckName(string findingName, out AudioSource audio){
        audio = null;
        if(findingName == name){
            audio = value;
            return true;
        }
        return false;
    }
}

