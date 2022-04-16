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
        if(parent.TryGetComponent(out Hand _hand))
        {
             transform.SetParent(parent.transform);
        }
    }
    
    
}
