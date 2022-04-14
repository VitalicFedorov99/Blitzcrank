using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject _objectInfluence;

    
    public void Press()
    {
        _objectInfluence.GetComponent<ILever>().Doing();
    }

    

}
