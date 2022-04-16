using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    
    [SerializeField] private float _time;

    [SerializeField] private Transform _positionUp;

    [SerializeField] private Transform _positionDown;

    [SerializeField] private float _speed;

    [SerializeField] private bool _isUpLava;

    [SerializeField] private bool _isStopUpdateLava=false;

    
    private void Start() 
    {
      //StartCoroutine(MoveLava());
    }
    
    private void Update() 
    {
        if(_isUpLava==true && _isStopUpdateLava==false){
            gameObject.transform.position=Vector3.Lerp(transform.position,_positionUp.position,_speed);
        
            if(Vector3.Distance(transform.position,_positionUp.position)<0.3f)
            {
               StartCoroutine(MoveLava());
                return;
            }
           
        }
        else if(_isUpLava==false && _isStopUpdateLava==false)
        {
            gameObject.transform.position=Vector3.Lerp(transform.position,_positionDown.position,_speed);
            //yield return new WaitForSeconds(_time);
            if(Vector3.Distance(transform.position,_positionDown.position)<0.3f)
            {
                StartCoroutine(MoveLava());
                return;
            }
            
        }
    }


    IEnumerator MoveLava()
    {   _isStopUpdateLava=true;
        yield return new WaitForSeconds(_time);
        Debug.Log("Лава");
        _isUpLava=!_isUpLava;
        _isStopUpdateLava=false;        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.TryGetComponent(out CharacterRobot robotCharacter))
        {
            robotCharacter.Death();
        }    
    }

}
