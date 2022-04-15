using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLaunch : MonoBehaviour
{
    [SerializeField] private GameObject _hand;

    [SerializeField] private GameObject _handMoveObject;
    //[SerializeField] private Transform _place;

    [SerializeField] private float _speed=2f;

    [SerializeField] private Rope _rope;
    [SerializeField] private Rope _ropeHandMoveObject;


    private bool _isHand = false;
    private bool _isHandMoveObject = false;
    public void CreateHand(Transform place,Vector3 target)
    {
        if(_isHand==false)
        {
            GameObject hand=Instantiate(_hand,place.position,Quaternion.identity);
            hand.GetComponent<Hand>().SetupHand(target,_speed,gameObject,_rope);
            _isHand=true;
        }
        //StartCoroutine(FlyHand(target,hand));
        //_hand.transform.position=Vector3.MoveTowards(transform.position,target,_speed);
    }

    public void CreateHandMoveObject(Transform place,Vector3 target)
    {
        if(_isHandMoveObject==false)
        {
            GameObject hand=Instantiate(_handMoveObject,place.position,Quaternion.identity);
            hand.GetComponent<HandForMoveObject>().SetupHand(target,_speed,gameObject,_ropeHandMoveObject);
            _isHandMoveObject=true;
        //StartCoroutine(FlyHand(target,hand));
        //_hand.transform.position=Vector3.MoveTowards(transform.position,target,_speed);
        }
    }

    public void SetIsHandMoveObject(bool flag)
    {
        _isHandMoveObject=flag;
    }

    public void SetIsHand(bool flag)
    {
        _isHand=flag;
    }
    

    IEnumerator FlyHand(Vector3 target,GameObject hand)
    {
        if(_isHandMoveObject==false)
        hand.transform.position=Vector3.MoveTowards(hand.transform.position,target,_speed);
        yield return new WaitForSeconds(4f);
    }


}
