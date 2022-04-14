using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBox : MonoBehaviour, IObjectGrab
{
    public void Grab(){}

    public void Grab(GameObject parent)
    {
        if(parent.TryGetComponent(out HandForMoveObject _hand))
        {
            transform.SetParent(_hand.transform);
            _hand.ObjectCaptured(gameObject);
        }
    }
}
