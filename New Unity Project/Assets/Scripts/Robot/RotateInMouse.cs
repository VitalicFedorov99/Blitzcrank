using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInMouse : MonoBehaviour
{
    public float offset;

    public TrajectoryRenderer line; 

    public float distanceRay=6f;

    public GameObject obj;
    public GameObject obj2;

    public GameObject obj1;

    public bool skillX=false;
    public bool skillZ=false;
    
    

    public bool _isRender;
    private void Update() 
    {   _isRender=true;
        Vector3 difference=Camera.main.ScreenToWorldPoint(Input.mousePosition)-obj.transform.position;
        //Vector3 difference=Camera.main.ScreenToWorldPoint(Input.mousePosition)-transform.position;
        float rotateZ=Mathf.Atan2(difference.y,difference.x)*Mathf.Rad2Deg;
        //Debug.Log(rotateZ);
        if (rotateZ>70 && rotateZ<110)
        {
            Debug.Log("false");
            _isRender=false;
        }
        if (rotateZ<-70 && rotateZ>-110)
        {
            Debug.Log("false");
            _isRender=false;
        }
        //handPobot.transform.rotation=Quaternion.Euler(0,0,rotateZ+offset);
        //transform.rotation=Quaternion.Euler(0,0,rotateZ+offset);

        //Vector3 localScale=Vector3.one;

       
        
        float enter;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        new Plane(-Vector3.forward, obj.transform.position).Raycast(ray, out enter);
        float dist=Vector2.Distance(ray.origin,obj.transform.position);
        //Debug.Log(dist);
        //Debug.Log(enter);

        Vector3 mouseInWorld = ray.GetPoint(enter);
        Vector3 speed = (mouseInWorld-transform.position) * 5;


        if(dist<=distanceRay && _isRender==true)
        {
            line.ShowTrajectory(obj.transform.position, speed);
        }

        if(Input.GetKeyDown(KeyCode.Z)&&_isRender==true && skillZ==true)
        {
            GetComponent<HandLaunch>().CreateHand(obj.transform,speed);
        }
        if(Input.GetKeyDown(KeyCode.X)&&_isRender==true && skillX==true)
        {
            GetComponent<HandLaunch>().CreateHandMoveObject(obj.transform,speed);
        }
    }
}
