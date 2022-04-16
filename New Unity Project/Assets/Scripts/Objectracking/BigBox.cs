using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBox : MonoBehaviour, IObjectGrab
{

    private bool _isCollision=false;

    private bool _isCollisionRight=false;
    private bool _isCollisionUp=false;
    private bool _isCollisionLeft=false;
    private bool _isCollisionDown=false;

    private HandForMoveObject _hand;

    [SerializeField] private GameObject _rightObj; 
    [SerializeField] private GameObject _lefttObj; 
    [SerializeField] private GameObject _downObj; 
    [SerializeField] private GameObject _upObj; 

    [SerializeField] private float _sizeCircleInOverlap=0.5f;

    public void Grab(){}

    public void Grab(GameObject parent)
    {
        if(parent.TryGetComponent(out HandForMoveObject _hand))
        {
            //transform.SetParent(_hand.transform);
            _hand.ObjectCaptured(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
            //_isCollision=true;
            //CheckCollisionPart();
            if(_hand!=null)
            {
                 _hand.SetCollisionObject(_isCollisionRight,_isCollisionLeft,_isCollisionDown,_isCollisionUp);
            }
            if(_hand!=null && other.gameObject.TryGetComponent(out Soldier soldier))
            {
                //soldier.
            }
    }

     private void OnCollisionExit2D(Collision2D other) 
     {
         //CheckCollisionPart();
         if(_hand!=null)
         {
            _hand.SetCollisionObject(_isCollisionRight,_isCollisionLeft,_isCollisionDown,_isCollisionUp);
         }
         //_isCollision=false;
     }

     private bool GetIsCollision()
     {
         return _isCollision;
     }
    

    // private void OnDrawGizmosSelected() {
    //      Gizmos.color = Color.yellow;
    //     Gizmos.DrawSphere(_rightObj.transform.position, _sizeCircleInOverlap);
    //     Gizmos.color = Color.blue;
    //     Gizmos.DrawSphere(_lefttObj.transform.position, _sizeCircleInOverlap);
    //      Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(_downObj.transform.position, _sizeCircleInOverlap);
    //     Gizmos.color = Color.green;
    //     Gizmos.DrawSphere(_upObj.transform.position, _sizeCircleInOverlap);
    // }

  /*  public void CheckCollisionPart()
    {
        _isCollisionRight=false;
        _isCollisionLeft=false;
        _isCollisionDown=false;
        _isCollisionUp=false;
        // Collider2D[] rightCollider = Physics2D.OverlapCircleAll(_rightObj.transform.position, _sizeCircleInOverlap); //IsCollidingRight = Physics2D.OverlapCircle(rightObject.transform.position, 0.5f, 1 << enemyLayer);
        // Collider2D[] leftCollider = Physics2D.OverlapCircleAll(_lefttObj.transform.position,_sizeCircleInOverlap);
        // Collider2D[] downCollider = Physics2D.OverlapCircleAll(_downObj.transform.position,_sizeCircleInOverlap);
        // Collider2D[] upCollider = Physics2D.OverlapCircleAll(_upObj.transform.position,_sizeCircleInOverlap);

        // foreach(Collider2D collider in rightCollider)
        // {
        //     if(collider.CompareTag("Ground")||collider.CompareTag("Robot")|| collider.CompareTag("Enemy"))
        //     {
        //         _isCollisionRight= true;
        //     }
        // }
        //  foreach(Collider2D collider in leftCollider)
        // {
        //     if(collider.CompareTag("Ground")||collider.CompareTag("Robot")|| collider.CompareTag("Enemy"))
        //     {
        //         _isCollisionLeft= true;
        //     }
        // }
        //  foreach(Collider2D collider in downCollider)
        // {
        //      if(collider.CompareTag("Ground")||collider.CompareTag("Robot")|| collider.CompareTag("Enemy"))
        //     {
        //         _isCollisionDown= true;
        //     }
        // }
        //  foreach(Collider2D collider in upCollider)
        // {
        //     if(collider.CompareTag("Ground")||collider.CompareTag("Robot")|| collider.CompareTag("Enemy"))
        //     {
        //         _isCollisionUp= true;
        //     }
        // }
        
        // Debug.Log("Вправо " + _isCollisionRight);
        // Debug.Log("Влево " + _isCollisionLeft);
        // Debug.Log("Внизу " + _isCollisionDown);
        // Debug.Log("Вверху " + _isCollisionUp);
    }  */ 
    
    public void SetHand(HandForMoveObject hand)
    {
        _hand=hand;
    }


}
