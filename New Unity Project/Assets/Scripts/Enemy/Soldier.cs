using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : ObservedObject,IEnemy,IObjectGrab
{

    [SerializeField] private int _health=3;
    [SerializeField] private float _timeReload;
    [SerializeField] private float _timeStun;
    [SerializeField] private float _speedSoldier;
    [SerializeField] private float _timeMean;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _pointTrap;
    [SerializeField] private Transform[] _pointWalk;  
    [SerializeField] private Transform _aim;    
    [SerializeField] private int _vectorDirection;    
    [SerializeField] private int idPointWalk=0;
    [SerializeField] private StateSoldier _state;
    [SerializeField] private StateSoldier _lastState;
    //[SerializeField] private string _textDialog;

    private Transform _pointMove;
    IEnumerator _soldierShoot;
    IEnumerator _soldierMove; 
    IEnumerator _soldierMean; 
 
  public void Walk()
  {
     _state=StateSoldier.Walk; 
    StopCoroutine(_soldierShoot);
    _soldierMove=Moving();
    StartCoroutine(_soldierMove);
  }

    public void Say()
    {

    }

    public void Stun()
    {
        Debug.Log("Stun");
        if(_lastState==StateSoldier.Shoot) StopCoroutine(_soldierShoot);
        if(_lastState==StateSoldier.Walk) StopCoroutine(_soldierMove);
        //StopCoroutine(_soldierMean);
        observedEvent?.Invoke(EnumObservedType.EnemyStun);
        StartCoroutine(Stuning());
    }


    
    
    public void Attack()
    {
      Debug.Log("Shoot");
      GameObject bull=Instantiate(_bullet,_aim.position,Quaternion.identity);
      bull.GetComponent<BulletEnemy>().Setup(_vectorDirection);
    }



    public void Death()
    {
        MissionObserver.GetObservedTypeAction(EnumObservedType.EnemyKill);
        Destroy(gameObject);
    }

    public void GoTrap()
    {
      _state=StateSoldier.Walk;
      
    }


   public void Grab()
   {
       if(_state!=StateSoldier.Stun)
       {
       _lastState=_state;
       _state=StateSoldier.Stun;
       //_health--;
       Stun();
    //    if(_health<=0)
    //    {
    //        Death();
    //    }
       }
   }

    public void Grab(GameObject parent)
    {

    }


  private void Start() 
  {
    //   _soldierMean=MakeAdecision();
    //   StartCoroutine(_soldierMean);
      _soldierShoot=Shoot();
      StartCoroutine(_soldierShoot);
      _state=StateSoldier.Shoot;
    // _state=StateSoldier.Walk;
    // _soldierMove=Moving();
    // StartCoroutine(_soldierMove);
    
  }
    IEnumerator Shoot()
    {  
        Attack();
        yield return new WaitForSeconds(_timeReload);
        _soldierShoot=Shoot();
        StartCoroutine(_soldierShoot);
    }
    IEnumerator Stuning()
    {  
        yield return new WaitForSeconds(_timeStun);
        if(_lastState==StateSoldier.Walk)
        {
            _state=_lastState;
            _soldierMove=Moving();
            StartCoroutine(_soldierMove);
        }
         if(_lastState==StateSoldier.Shoot)
         {
             _state=_lastState;
             _soldierShoot=Shoot();
             StartCoroutine(_soldierShoot);
         }
        //_soldierMean=MakeAdecision();
        //StartCoroutine(_soldierMean);
        Debug.Log("StunEnd");
    }
  /*  IEnumerator MakeAdecision()
    {
        yield return new WaitForSeconds(_timeMean);
        if (_state==StateSoldier.Shoot)
        {
            int rand = Random.Range(0,1);
            if(rand==0)
            {
                _state=StateSoldier.Shoot;
                 _soldierShoot=Shoot();
                StartCoroutine(_soldierShoot);
            }
            else
            {
                Walk();
            }
        }
        _soldierMean=MakeAdecision();
        StartCoroutine(_soldierMean);
    }
    */
    IEnumerator Moving()
    {   
        Debug.Log("Walk");
        transform.position=Vector3.MoveTowards(transform.position,_pointMove.position,_speedSoldier);
        yield return new WaitForSeconds(0.5f);
        if(Vector3.Distance(transform.position,_pointMove.position)>=1)
        {
            _state=StateSoldier.Walk;
            _soldierMove=Moving();
            StartCoroutine(_soldierMove);
        }
        else
        {   
            int rand = Random.Range(0,1);
            if(rand==0)
            {
                _state=StateSoldier.Shoot;
                 _soldierShoot=Shoot();
                StartCoroutine(_soldierShoot);
            }
            else
            {
                if(idPointWalk==0)
                {
                    idPointWalk=1;
                     _pointMove=_pointWalk[idPointWalk];
                    GetComponent<SpriteRenderer>().flipX=true;
                    _vectorDirection=-1;
                }
                else 
                {
                    idPointWalk=0;
                    _pointMove=_pointWalk[idPointWalk];
                    GetComponent<SpriteRenderer>().flipX=false;
                    _vectorDirection=1;
                }
                _state=StateSoldier.Walk;
                _soldierMove=Moving();
                StartCoroutine(_soldierMove);
                
             }
        }
        
    }
}
