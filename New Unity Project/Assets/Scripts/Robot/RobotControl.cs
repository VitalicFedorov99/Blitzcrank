using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
   private Fly _flyComponent;
   private Shield _shieldComponent;

   private  PressLever _pressLever;
   [SerializeField] private StateRobot _stateRobot;
   [SerializeField] private StateRobot _combatState; 
   [SerializeField] private StateRobot _lastState;

   [SerializeField] private StateRobot _aimState; 
   [SerializeField] private StateRobot _lastCombatState; 



    [SerializeField] private bool _isCanPress=false;


    private void Start()
    {
        _flyComponent=GetComponent<Fly>();
        _shieldComponent=GetComponent<Shield>();
        _pressLever=GetComponent<PressLever>();
        _stateRobot=StateRobot.Neutral;
        _combatState=StateRobot.Neutral;
        _aimState=StateRobot.Neutral;
        _lastState=StateRobot.Neutral;
        _lastCombatState=StateRobot.Neutral;    
    }

    private void Update() 
    {
       FlyComponentControl();
       ShieldComponentControl();
       if(Input.GetKeyDown(KeyCode.Z))
       {
           _aimState=StateRobot.Aiming;
       }
       if(_isCanPress==true)
       {
           if(Input.GetKeyDown(KeyCode.E))
           {
               _pressLever.Press();
           }
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
            _stateRobot= StateRobot.Fly;
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


    public void UseLever(bool flag)
    {
        _isCanPress=flag;
    }

}
