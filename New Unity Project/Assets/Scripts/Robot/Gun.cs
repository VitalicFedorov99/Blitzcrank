using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Power = 100;

    public TrajectoryRenderer Trajectory;
 
    public GameObject _obj;
    [SerializeField] private float _towerRotateSpeed=5f;

   
    //public TrajectoryRendererAdvanced Trajectory;

    private Camera mainCamera;
    
    private void Start()
    {
        mainCamera = Camera.main;
    }

   /* private void Update()
    {
        Vector3 screenMousePosition=Input.mousePosition;
        Vector3 worldMousePosition=mainCamera.ScreenToWorldPoint(screenMousePosition);
        Debug.Log(worldMousePosition);
        transform.LookAt(worldMousePosition);    
    }*/

    private void FixedUpdate()
    {
        float enter;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        new Plane(-Vector3.forward, transform.position).Raycast(ray, out enter);
        Vector3 mouseInWorld = ray.GetPoint(enter);

        Vector3 speed = (mouseInWorld - transform.position) * Power;
        //Debug.Log(" x: "+speed.x+" y: "+speed.y);
        //transform.LookAt(transform, speed);
    
        transform.rotation = Quaternion.LookRotation(new Vector3(speed.x,speed.y,0),new Vector3(speed.x,0,speed.y));
        
         //_obj.transform.LookAt(_obj.transform, new Vector3(speed.x,0,speed.y));
        Debug.Log(" x: "+transform.rotation.x+" y: "+transform.rotation.y+" z: "+transform.rotation.z);

        
        Trajectory.ShowTrajectory(transform.position, speed);

        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            bullet.AddForce(speed, ForceMode.VelocityChange);
            //Trajectory.AddBody(bullet);
        }
        
           
            //Vector3 speed = (mouseInWorld - transform.position) * Power;
        //transform.rotation = Quaternion.LookRotation(speed);
            //Trajectory.ShowTrajectory(transform.position, _obj.transform.up);
        
    }
    


}
