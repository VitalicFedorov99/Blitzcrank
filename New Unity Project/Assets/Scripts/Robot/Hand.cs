using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blitzcrank.Robot;
public class Hand : MonoBehaviour
{
    
    private GameObject _robot;
    private Vector3 _target;
    private float _speed;

    private GameObject _grabObject;

    private Transform _startPos;
    [SerializeField]private float _dist=4f;

    [SerializeField]private bool _isHandBack=false;
    
    [SerializeField]private bool _isHandtoHook=false;

    [SerializeField]private AudioSource _audio; 

    private Rope _rope;
    public void SetupHand(Vector3 target,float speed, GameObject robot,Rope rope)
    {
        AudioClip clip;
        AudioManager.GetAudioSource("Skill1",out clip);
        _audio=GetComponent<AudioSource>();
         _audio.clip=clip;
        _target=target;
        _speed=speed;
        _robot=robot;
        _startPos=robot.transform;
        _isHandBack=false;
        _rope=rope;
        _rope.Setup(gameObject);
        StartCoroutine(Fly());
    }

    // Update is called once per frame
    void Update()
    {
        if(_isHandtoHook==false)
        {
            if(_isHandBack==false)
            {
                if(Input.GetKeyDown(KeyCode.Z))
                {
                     _isHandBack=true;
                }
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
                    AddItemInventory();
                    DestroyHand();
                }
            }
        }
        
        
    }




    public void DestroyHand()
    {
        _rope.DestroyHand();
        _robot.GetComponent<HandLaunch>().SetIsHand(false);
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
            _audio.Play();
            //AudioManager.GetAudioSource()
            _isHandBack=true;
        }
        if(other.TryGetComponent(out IEnemy enemy))
        {
             _isHandBack=true;
            //Destroy(gameObject);
        }
        if(other.TryGetComponent(out Hook hook))
        {
            _isHandtoHook=true;
            RobotMovetoHand();
        }
        if(other.CompareTag("Ground"))
        {
           _isHandBack=true;
            //Destroy(gameObject);
        }
        if(other.TryGetComponent(out Lava lava))
        {
            _isHandBack=true;
        }
    }
   

   public void RobotMovetoHand()
   {
       _robot.GetComponent<Move>().SetupHand(gameObject);
    
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
