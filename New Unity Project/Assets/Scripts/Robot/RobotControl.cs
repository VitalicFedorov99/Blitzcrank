using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
   private  PressLever _pressLever;
   


    [SerializeField] private bool _isCanPress=false;


    private void Start()
    {
        _pressLever=GetComponent<PressLever>();
        
    }

    private void Update() 
    {
       
       if(Input.GetKeyDown(KeyCode.Z))
       {
       }
       if(_isCanPress==true)
       {
           if(Input.GetKeyDown(KeyCode.E))
           {
               _pressLever.Press();
           }
       }     
    }



  

   


    public void UseLever(bool flag)
    {
        _isCanPress=flag;
    }

}
