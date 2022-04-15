using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blitzcrank.Robot;
public class HandForMoveObject : MonoBehaviour
{
    private GameObject _robot;

     private Vector3 _target;

    private float _speed;
    
    

    private GameObject _grabObject;
     private Transform _startPos;

     [SerializeField]private float _dist=4f;

     [SerializeField] private float _speedHandWithObject; 

     private bool _isHandBack=false;

     private bool _isHandGrabbed=false;

     private Rope _rope;

     public void SetupHand(Vector3 target,float speed, GameObject robot,Rope rope)
     {
        _target=target;
        _speed=speed;
        _robot=robot;
        _startPos=robot.transform;
        _isHandBack=false;
        _rope=rope;
        _rope.Setup(gameObject);
       // StartCoroutine(Fly());
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
            //Destroy(gameObject);
        }
     }

    private void Update() 
    {
            if(_isHandGrabbed==true)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(Vector2.left * Time.deltaTime*_speedHandWithObject);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(Vector2.right * Time.deltaTime*_speedHandWithObject);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(Vector2.up * Time.deltaTime*_speedHandWithObject);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(Vector2.down * Time.deltaTime*_speedHandWithObject);
                }
                if(Input.GetKeyDown(KeyCode.X))
                {
                    DestroyGrabObj();
                }
            }
            else
            {
                if(_isHandBack==false)
                {
                    if(_target!=null&&Vector3.Distance(_robot.transform.position,transform.position)<=_dist)
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
                        DestroyHand();
                    }
                }
            }
            
    }

     public void ObjectCaptured(GameObject obj)
     {
         _robot.GetComponent<Move>().NotMove();
         _grabObject=obj;
         _isHandGrabbed=true;
     }

     public void DestroyGrabObj()
     {
         _grabObject.GetComponent<Rigidbody2D>().gravityScale=1;
         _grabObject.transform.parent=null;
         _grabObject=null;
         _isHandGrabbed=false;
     }

     
    public void DestroyHand()
    {
        _rope.DestroyHand();
        _robot.GetComponent<HandLaunch>().SetIsHandMoveObject(false);
        Destroy(gameObject);
    }
     

}
