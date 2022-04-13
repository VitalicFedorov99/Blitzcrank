using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] private int _flyHeight=1;

    public void BlastOff()
    {
        transform.position=new Vector3(transform.position.x,transform.position.y+_flyHeight,transform.position.z);
    }

    public void Landing()
    {
        transform.position=new Vector3(transform.position.x,transform.position.y-_flyHeight,transform.position.z);
    }

    

}
