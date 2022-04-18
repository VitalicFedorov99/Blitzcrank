using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _speed;
    void Start()
    {
        transform.position=new Vector3(_playerTransform.position.x,_playerTransform.position.y,-10);
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerTransform!=null)
        {
            Vector3 target=new Vector3(_playerTransform.position.x,_playerTransform.position.y,-10);
            Vector3 pos= Vector3.Lerp(transform.position,target,_speed*Time.deltaTime);
            transform.position=pos;
        }

    }
}
