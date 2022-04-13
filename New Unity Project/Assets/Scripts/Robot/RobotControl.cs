using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
   private Fly _flyComponent;
   private Shield _shieldComponent;
   private StateRobot _stateRobot;

   private StateRobot _combatState; 
   private StateRobot _lastState;

   private StateRobot _aimState; 
   private StateRobot _lastCombatState; 

   


    private void Start()
    {
        _flyComponent=GetComponent<Fly>();
        _shieldComponent=GetComponent<Shield>();
        _stateRobot=StateRobot.Neutral;
        _combatState=StateRobot.Neutral;
        _aimState=StateRobot.Neutral;    
    }

    private void Update() 
    {
       FlyComponentControl();
       ShieldComponentControl();
       if(Input.GetKeyDown(KeyCode.Z))
       {
           _aimState=StateRobot.Aiming;
       }     
    }



    private void FlyComponentControl()
    {
        if(Input.GetKeyDown(KeyCode.X)&& _stateRobot==StateRobot.Fly)
        {
            _flyComponent.Landing();
            _stateRobot=_lastState;
            Debug.Log("я приземляюсь");
            return;
        }    

        if(Input.GetKeyDown(KeyCode.X) && _stateRobot != StateRobot.Fly)
        {
            _flyComponent.BlastOff();
            _stateRobot=StateRobot.Fly;
            Debug.Log("я лечу");
            return;
        }  
    }

    private void ShieldComponentControl()
    {
        if(Input.GetKeyDown(KeyCode.C)&& _combatState!=StateRobot.Shield)
        {
            _shieldComponent.ShieldOn();
            _combatState=StateRobot.Shield;
            Debug.Log("щит активирован");
            return;
        }   
        if(Input.GetKeyDown(KeyCode.C)&& _combatState==StateRobot.Shield)
        {
            _shieldComponent.ShieldOff();
            _combatState=_lastCombatState;
            Debug.Log("щит Деактивирован");
            return;
        }     
    }

}
