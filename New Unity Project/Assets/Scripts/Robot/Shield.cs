using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject _shield;

    [SerializeField] private int _armor;
    
    
    private CharacterRobot _character;

    private void Start() 
    {
        _character=GetComponent<CharacterRobot>();    
    }

    public void ShieldOn()
    {
        _shield.SetActive(true);
    }

     public void ShieldOff()
    {
        _shield.SetActive(false);
    }
}
