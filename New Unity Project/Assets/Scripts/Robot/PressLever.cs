using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressLever : MonoBehaviour
{

    private Lever _lever;
    
    private RobotControl _robotControl;

    private void Start() 
    {
        _robotControl=GetComponent<RobotControl>();    
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.TryGetComponent(out Lever lever))
        {
            //lever.Press();
            _lever=lever;
            _robotControl.UseLever(true);
        }    
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.TryGetComponent(out Lever lever))
        {
            _lever=null;
            _robotControl.UseLever(false);
        } 
    }

    public void Press()
    {
        _lever.Press();
    }

    
}
