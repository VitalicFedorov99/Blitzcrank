using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRobot : MonoBehaviour
{
    
    [SerializeField] private  int _health;

    [SerializeField] private int _batary;
    

    public void Damage(int damage)
    {
        _health-=damage;
        Debug.Log("AЙ");
        if(_health<=0)
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("умираю");
        MissionObserver.GetObservedTypeAction(EnumObservedType.RobotDead);
    }


}
