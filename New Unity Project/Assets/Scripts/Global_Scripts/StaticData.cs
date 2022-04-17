using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StaticData", menuName = "Data")]
public class StaticData : ScriptableObject 
{
    [SerializeField] private int countlevel=30;

   [SerializeField] private int [] StarsOnLevels;

    [SerializeField] private bool [] CompletedLevels;

    public void SetLevelStars(int numberLevel,int countStars)
    {
        if(numberLevel<countlevel)
        {
            if(StarsOnLevels[numberLevel]<countStars)
            StarsOnLevels[numberLevel]=countStars;
            CompletedLevels[numberLevel]=true;
        }
    }

    public void SetupData()
    {
        for(int i=0;i<countlevel;i++)
        {
            StarsOnLevels[i]=0;
            CompletedLevels[i]=false;
        }
    }
}

