using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MissonInfo
{
    private string missionName;
    private bool isMissionComplete;
    private int starsCount;

    public int StarsCount { get => starsCount; set {
        if(value>0 && value<=3){
        starsCount = value; 
        isMissionComplete = true;
        }}}

    public string MissionName { get => missionName; set => missionName = value; }
    public bool IsMissionComplete { get => isMissionComplete; }
}
