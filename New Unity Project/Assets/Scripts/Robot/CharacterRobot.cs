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
    }

    public void Death()
    {
        Debug.Log("умираю");
    }


}
