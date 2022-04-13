using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
   [SerializeField] private float _speed;  

   [SerializeField] private float _timeLife; 

   [SerializeField] private float distShoot;
   private Vector3 _pointShoot;



   public void Setup(int vectorDirection)
   {
       _pointShoot=new Vector3(transform.position.x+distShoot*vectorDirection,transform.position.y,transform.position.z);
       StartCoroutine(TimeLifeBullet());
   }

   private void Update()
   {    
       if(_pointShoot!=null)
       {
            transform.position=Vector3.MoveTowards(transform.position,_pointShoot,_speed);
       }
   }

    IEnumerator TimeLifeBullet()
    {  
        yield return new WaitForSeconds(_timeLife);
        Destroy(gameObject);
    }

}
