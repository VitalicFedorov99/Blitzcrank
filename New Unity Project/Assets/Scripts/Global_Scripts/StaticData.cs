using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StaticData", menuName = "Data")]
public class StaticData : ScriptableObject 
{
    [SerializeField] private int _countlevel=30;

    [SerializeField] private int [] _starsOnLevels;

    [SerializeField] private bool [] _completedLevels;

    

    public void SetLevelStars(int numberLevel,int countStars)
    {
        if(numberLevel<_countlevel)
        {
            if(_starsOnLevels[numberLevel]<countStars)
            _starsOnLevels[numberLevel]=countStars;
            _completedLevels[numberLevel]=true;
        }
    }


    public int[] GetStarsOnLevels()
    {
            return _starsOnLevels;
    }

    public bool[] GetCompletedLevels()
    {
            return _completedLevels;
    }
    

    public void SetupData()
    {
        for(int i=0;i<_countlevel;i++)
        {
            _starsOnLevels[i]=0;
            //_completedLevels[i]=false;
        }
    }
}

