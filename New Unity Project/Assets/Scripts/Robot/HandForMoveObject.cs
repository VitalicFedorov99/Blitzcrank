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
   
    //private BigBox _box;

     [SerializeField] private float _dist=4f;

     [SerializeField] private float _distRobotBetweenHand=5f; 

     [SerializeField] private float _speedHandWithObject; 

     private bool _isHandBack=false;

     private bool _isHandGrabbed=false;

     private bool _isUse=false;

     private Rope _rope;

     private bool _blockRight=false;
     private bool _blockLeft=false;
     private bool _blockDown=false; 
     private bool _blockUp=false;

     private AudioSource _audio;
     public void SetupHand(Vector3 target,float speed, GameObject robot,Rope rope)
     {
         _audio=GetComponent<AudioSource>();
         AudioClip clip;
         AudioManager.GetAudioSource("Skill2",out clip);
        _audio.clip=clip;
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
        if(_isUse==false)
        {
            if(other.TryGetComponent(out IObjectGrab obj))
            {
                obj.Grab(gameObject);
                obj.Grab();
            }
            if(other.TryGetComponent(out IEnemy enemy))
            {
                 _isHandBack=true;
                //Destroy(gameObject);
            }
            if(other.CompareTag("Ground"))
            {
                _isHandBack=true;
            
            }
            if(other.TryGetComponent(out Hook hook))
            {
                 _isHandBack=true;
            }
            if(other.TryGetComponent(out Box box))
            {
                 _isHandBack=true;
            }
            if(other.TryGetComponent(out Lava lava))
            {
                 _isHandBack=true;
            }
        }
     }

    private void Update() 
    {
            if(_isHandGrabbed==true)
            {   
                if (Input.GetKey(KeyCode.A))
                {   
                    if (Vector3.Distance(new Vector3(transform.position.x-1,transform.position.y,transform.position.z),_robot.transform.position)<=_distRobotBetweenHand) 
                    // && _collisionLeft==false)
                    {
                        _blockLeft=false;
                    }
                    else
                    {
                        _blockLeft=true;
                    }
                    if(_blockLeft==false)
                    { 
                        _grabObject.transform.Translate(Vector2.left * Time.deltaTime*_speedHandWithObject);
                        gameObject.transform.position=_grabObject.transform.position;
                    }
                   
                }
                if (Input.GetKey(KeyCode.D))
                {
                    if (Vector3.Distance(new Vector3(transform.position.x+1,transform.position.y,transform.position.z),_robot.transform.position)<=_distRobotBetweenHand)
                    //&&_collisionRight==false)
                    {
                        _blockRight=false;
                    }
                    else
                    {
                        _blockRight=true;
                    }
                    if(_blockRight==false)
                    {
                         _grabObject.transform.Translate(Vector2.right * Time.deltaTime*_speedHandWithObject);
                         gameObject.transform.position=_grabObject.transform.position;
                    }
                }
                if (Input.GetKey(KeyCode.W))
                {
                    if (Vector3.Distance(new Vector3(transform.position.x,transform.position.y+1,transform.position.z),_robot.transform.position)<=_distRobotBetweenHand)
                     //&& _collisionkUp==false)
                    {
                        _blockUp=false;
                    }
                    else
                    {
                        _blockUp=true;
                    }
                    if(_blockUp==false)
                    {
                        _grabObject.transform.Translate(Vector2.up * Time.deltaTime*_speedHandWithObject);
                        gameObject.transform.position=_grabObject.transform.position;
                    }
                }
                if (Input.GetKey(KeyCode.S))
                {
                    if (Vector3.Distance(new Vector3(transform.position.x,transform.position.y-1,transform.position.z),_robot.transform.position)<=_distRobotBetweenHand)
                    //&&  _collisionDown==false)
                    {
                        _blockDown=false;
                    }
                    else
                    {
                        _blockDown=true;
                    }
                    if(_blockDown==false)
                    {
                        _grabObject.transform.Translate(Vector2.down * Time.deltaTime*_speedHandWithObject);
                        gameObject.transform.position=_grabObject.transform.position;
                        
                    }
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
                    else 
                    {
                        _isHandBack=true;
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
         _audio.Play();
         gameObject.transform.SetParent(obj.transform);
         _robot.GetComponent<Move>().GetIsNotMove(true);
         _grabObject=obj;
          if(_grabObject.TryGetComponent(out BigBox box))
          {
              box.SetHand(GetComponent<HandForMoveObject>());
          }
        //  _box=_grabObject.GetComponent<BigBox>();
         _grabObject.GetComponent<Rigidbody2D>().gravityScale=0;
         //_grabObject.GetComponent<BoxCollider2D>().enabled=false;
         _isHandGrabbed=true;
     }

     public void DestroyGrabObj()
     {
          _audio.Play();
         Debug.Log("Отпускаю");
         _isUse=true;
         if(_grabObject.TryGetComponent(out BigBox box))
          {
              box.DeleteHand();
          }
         _grabObject.GetComponent<Rigidbody2D>().gravityScale=1;
         gameObject.transform.parent=null;
         _grabObject=null;
         _isHandGrabbed=false;
         _isHandBack=true;
         
     }

     
    public void DestroyHand()
    {
        _rope.DestroyHand();
        _robot.GetComponent<HandLaunch>().SetIsHandMoveObject(false);
        _robot.GetComponent<Move>().GetIsNotMove(false);
        Destroy(gameObject);
    }

     
    

}
