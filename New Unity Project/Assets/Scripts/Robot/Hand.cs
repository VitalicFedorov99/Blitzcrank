using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    
    private Transform _robot;
    private Vector3 _target;
    private float _speed;

    private GameObject _grabObject;

    private Transform _startPos;
    [SerializeField]private float _dist=4f;

    [SerializeField]private bool _isHandBack=false;
    public void SetupHand(Vector3 target,float speed,Transform robot)
    {
        _target=target;
        _speed=speed;
        _robot=robot;
        _startPos=robot;
        _isHandBack=false;
        StartCoroutine(Fly());
    }

    // Update is called once per frame
    void Update()
    {
        if(_isHandBack==false)
        {
            if(_target!=null&&Vector3.Distance(_robot.position,transform.position)<=_dist)
            {
                transform.position=Vector3.MoveTowards(transform.position,_target,_speed);
            }
        }
        else
        {
            if(Vector3.Distance(_startPos.position,transform.position)>=0.5)
            {
                transform.position=Vector3.MoveTowards(transform.position,_startPos.position,0.2f);
                Debug.Log("Держу");
            }
            else 
            {   
                AddItemInventory();
                DestroyHand();
            }
        }
        
    }




    private void DestroyHand()
    {
        Destroy(gameObject);
    }

    public void AddItemInventory()
    {
        _robot.gameObject.GetComponent<Inventory>().AddItem(_grabObject);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out IObjectGrab obj))
        {
            obj.Grab(gameObject);
            obj.Grab();
        }
        if(other.TryGetComponent(out IEnemy enemy))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   

    IEnumerator Fly()
    {  
        yield return new WaitForSeconds(1f);
        HandBack();
    }
    public void HandBack()
    {
        _isHandBack=true;
    }

}
