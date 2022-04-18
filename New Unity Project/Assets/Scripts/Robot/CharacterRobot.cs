using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterRobot : MonoBehaviour
{
    
    [SerializeField] private  int _health;

    [SerializeField] private int _batary;
    
    [SerializeField] private Text _textHP;

    private Animator _animator;
    private bool _endGame;

    private void Start() 
    {
    _textHP.text=_health.ToString();
    _animator=GetComponent<Animator>();    
    }
    public void Damage(int damage)
    {
        _health-=damage;
        _textHP.text=_health.ToString();    
        Debug.Log("AЙ");
        if(_health<=0)
        {
            Death();
        }
    }

    public void Death()
    {
        _animator.SetTrigger("DeathRobot");
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
