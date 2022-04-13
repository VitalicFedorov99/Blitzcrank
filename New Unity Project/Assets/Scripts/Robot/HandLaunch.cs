using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLaunch : MonoBehaviour
{
    [SerializeField] private GameObject _hand;
    //[SerializeField] private Transform _place;

    [SerializeField] private float _speed=2f;
    public void CreateHand(Transform place,Vector3 target)
    {
     GameObject hand=Instantiate(_hand,place.position,Quaternion.identity);
        hand.GetComponent<Hand>().SetupHand(target,_speed,gameObject.transform);
        //StartCoroutine(FlyHand(target,hand));
        //_hand.transform.position=Vector3.MoveTowards(transform.position,target,_speed);
    }
    

    IEnumerator FlyHand(Vector3 target,GameObject hand)
    {
        hand.transform.position=Vector3.MoveTowards(hand.transform.position,target,_speed);
        yield return new WaitForSeconds(4f);
    }
}
