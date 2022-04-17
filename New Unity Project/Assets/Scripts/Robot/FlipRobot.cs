using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipRobot : MonoBehaviour
{
   private Vector3 pos;
   private Camera main;

   private SpriteRenderer _sprite;

   private RotateInMouse _robot; 
   
   private CharacterRobot _robotCharacter;
   private void Start() 
   {
    main=Camera.main;  
    _sprite=GetComponent<SpriteRenderer>();  
    _robot=GetComponent<RotateInMouse>();
    _robotCharacter=GetComponent<CharacterRobot>();
   }
   private void Update()
   {
       if(_robotCharacter.GetEndGame()==false)
       {
            pos=main.WorldToScreenPoint(transform.position);
            Flip();
       }
   }

   private void Flip()
   {
       if(Input.mousePosition.x<pos.x)
       {
           _sprite.flipX=true;
           _robot.obj=_robot.obj2;
       }
       if(Input.mousePosition.x>pos.x)
       {
           //FlipSprite(false);
            _sprite.flipX=false;
            _robot.obj=_robot.obj1;
       } 
   }

  

}
