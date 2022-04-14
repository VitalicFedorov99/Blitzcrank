using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
  
  [SerializeField] private GameObject _robot;
  private LineRenderer _lineRender;

  private GameObject _hand;
    
  private void Start() 
  {
      _lineRender=GetComponent<LineRenderer>();

  }

  public void Setup(GameObject hand)
  {
      _hand=hand;
  }

  public void DestroyHand()
  {
      _hand=null;
  }

  private void Update() 
  {
    _lineRender.positionCount=0;
    if(_hand!=null)
    {
        //Vector3[] points = new Vector3[3];
        _lineRender.positionCount = 2;
        _lineRender.SetPosition(0,_robot.transform.position);
        _lineRender.SetPosition(1,_hand.transform.position);
    }    
  }
}
