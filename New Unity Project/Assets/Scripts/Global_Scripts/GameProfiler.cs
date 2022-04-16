using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProfiler : ScriptableObject
{
    private MissonInfo[] missionsResult;
   // private Dictionary<string, bool> skills = new Dictionary<string, bool> 
    //{{"first", true}, {"second", false}, {"third", false}};

    [SerializeField] private bool skillHandZ=true;

    [SerializeField] private bool skillHandX=false;

    public MissonInfo MissionResultCheck(int id){
        return missionsResult[id];
    }

    public void MissionComplete (string _missionName, int starCount){
        for (int i = 0; i < missionsResult.Length; i++)
        {
            MissonInfo mission = missionsResult[i];
            if (mission.MissionName == _missionName) {
                mission.StarsCount = starCount;
                return;
            }
        }
    }

    public void GetSkillHand(out bool skillZ,out bool skillX)
    {
        skillZ=skillHandZ;
        skillX=skillHandX;
    }
}
