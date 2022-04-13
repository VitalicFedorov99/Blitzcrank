using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour,IObjectGrab
{
    public void Grab()
    {
        //Debug.Log("Box");
    }

    public void Grab(GameObject parent)
    {
        transform.SetParent(parent.transform);
    }
    
    
}
