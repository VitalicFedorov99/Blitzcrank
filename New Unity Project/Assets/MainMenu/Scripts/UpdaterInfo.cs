using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdaterInfo : MonoBehaviour
{
    [SerializeField] private MissionElementScript[] _missions;
    [SerializeField] private int _progressPlayer;
    
    [SerializeField] private StaticData _dataPlayer;

    [SerializeField] private int _countMissions;

    [SerializeField] private int [] _starsOnLevels;

    [SerializeField] private bool [] _completedLevels;

    // Start is called before the first frame update
    void Start()
    {
        UpdateInfoMissia();
    }

    public void UpdateInfoMissia()
    {   
        _starsOnLevels=_dataPlayer.GetStarsOnLevels();
        _completedLevels=_dataPlayer.GetCompletedLevels();
        for(int i=0;i<_countMissions;i++)
        {    
             _missions[i].Setup(_starsOnLevels[i],_completedLevels[i]);
        }
    }
}
