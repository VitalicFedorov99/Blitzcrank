using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRobot : MonoBehaviour
{
    
    [SerializeField] private  int _health;

    [SerializeField] private int _batary;
    
    private bool _endGame;
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
        _endGame=true;
        MissionObserver.GetObservedTypeAction(EnumObservedType.RobotDead);
    }

  public bool GetEndGame()
  {
      return _endGame; 
  }

  public  void SetEndGame(bool flag)
  {
      _endGame=flag;
  }
}
