using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBox : MonoBehaviour, IObjectGrab
{
    private HandForMoveObject _hand;

    public void Grab(){}

    public void Grab(GameObject parent)
    {
        if(parent.TryGetComponent(out HandForMoveObject _hand))
        {
            _hand.ObjectCaptured(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
          
            if(_hand!=null && other.gameObject.TryGetComponent(out Soldier soldier))
            {
                soldier.Death();
            }
    }
    
    
    public void SetHand(HandForMoveObject hand)
    {
        _hand=hand;
    }


}
