using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBox : MonoBehaviour, IObjectGrab
{

    private bool _isCollision=false;
    public void Grab(){}

    public void Grab(GameObject parent)
    {
        if(parent.TryGetComponent(out HandForMoveObject _hand))
        {
            transform.SetParent(_hand.transform);
            _hand.ObjectCaptured(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
            _isCollision=true;
    }

     private void OnCollisionExit2D(Collision2D other) 
     {
         _isCollision=false;
     }

     private bool GetIsCollision()
     {
         return _isCollision;
     }
    
}
