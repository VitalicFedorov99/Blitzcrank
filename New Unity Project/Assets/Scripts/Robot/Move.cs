using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blitzcrank.Robot
{
    public class Move : MonoBehaviour
    {

        [SerializeField] private float _speed=5f;
        private void Update()
        {
            Moved();
        }

        private void Moved()
        {
                float rotation = Input.GetAxis("Horizontal") * _speed;
                float translation = Input.GetAxis("Vertical") * _speed;

                rotation *= Time.deltaTime;

                transform.Translate(rotation, translation,0);

                
        }
    }
}
