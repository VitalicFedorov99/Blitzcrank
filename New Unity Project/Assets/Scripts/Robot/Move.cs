using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blitzcrank.Robot
{
    public class Move : MonoBehaviour
    {


        private bool _isMoveToHand=false;
        
        private bool _isNotMove=false;
        private GameObject _hand;
        private CharacterRobot _characterRobot;
        
        private Animator _animator;
        [SerializeField] private float _speedMoveToHand;

        [SerializeField] private float _distToHand;

        [SerializeField] private float _speed=5f;

         private FlipRobot _flipper;


        private void Start()
        {
            _characterRobot=GetComponent<CharacterRobot>();
            _animator=GetComponent<Animator>();
            _flipper=GetComponent<FlipRobot>();
        }
        private void Update()
        {
            if(_characterRobot.GetEndGame()==false)
            {
                if(_isMoveToHand==true)
                {
                    moveToHand();
                }
                else if(_isMoveToHand==false && _isNotMove==false)
                {
                    Moved();
                }

            }
            else
            {
                _animator.SetBool("WalkRobot",false);
            }
        }

        private void Moved()
        {
                float rotation = Input.GetAxis("Horizontal") * _speed;
                
                if(rotation==0)
                {
                    _animator.SetBool("WalkRobot",false);
                }
                else
                {
                     _animator.SetBool("WalkRobot",true);
                }
                // if(rotation>0)
                // {
                //     _flipper.Flip(false);
                // }
                // if(rotation<0)
                // {
                //     _flipper.Flip(true);
                // }
                
                rotation *= Time.deltaTime;

                transform.Translate(rotation, 0,0);

                
        }


        public void SetupHand(GameObject hand)
        {
            _hand=hand;
            _isMoveToHand=true;
        }

        public void DestroyHand()
        {
            _hand.GetComponent<Hand>().DestroyHand();
            _hand=null;
        }
        public void moveToHand()
        {
            if(_hand!=null)
            {
                transform.position=Vector3.Lerp(transform.position,_hand.transform.position,_speedMoveToHand);
                if(Vector3.Distance(transform.position,_hand.transform.position)<_distToHand)
                {
                    DestroyHand();
                    _isMoveToHand=false;
                }
            }
        }

        public void GetIsNotMove(bool flag)
        {
            _isNotMove=flag;
        }
        

        

        
    }
}
