using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,ILever
{
   
    [SerializeField] private Transform _openDoor;
    [SerializeField] private Transform _closeDoor;

    [SerializeField] private bool _isOpen;

    [SerializeField] private float _time;

    [SerializeField] private float _speed;

    [SerializeField] private bool _isStopUpdateDoor;
    public void Doing()
    {
        Debug.Log("OPen");
        StartCoroutine(MoveDoor());
    }
    
    
    IEnumerator MoveDoor()
    {  
        yield return new WaitForSeconds(_time);
        _isStopUpdateDoor=false;
        if(_isOpen==true && _isStopUpdateDoor==false){
            gameObject.transform.position=Vector3.Lerp(transform.position,_closeDoor.position,_speed);
            //yield return new WaitForSeconds(_time);
             _isStopUpdateDoor=true;
            if(Vector3.Distance(transform.position, _closeDoor.position)<0.3f)
            {
                _isOpen=false;
              
            }
            else StartCoroutine(MoveDoor());
        }
        else if(_isOpen==false && _isStopUpdateDoor==false)
        {
            gameObject.transform.position=Vector3.Lerp(transform.position,_openDoor.position,_speed);
            //yield return new WaitForSeconds(_time);
              _isStopUpdateDoor=true;
            if(Vector3.Distance(transform.position,_openDoor.position)<0.3f)
            {
                _isOpen=true;
                
            }
            else StartCoroutine(MoveDoor());
        }
        
       
    }

}
