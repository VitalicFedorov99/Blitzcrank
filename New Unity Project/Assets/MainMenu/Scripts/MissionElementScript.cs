using System;
using UnityEngine;
using UnityEngine.UI;

public class MissionElementScript : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite availableMissionSprite;
    [SerializeField] private Sprite obtainedStar;

    [Header("UI-Elements")]
    [SerializeField] private Image[] stars;
    [SerializeField] private Text missionNumber;

    [Header("TEST")]
    [SerializeField] private MissionInfo missionInfo;
    private string missionTechName;

    private void Setup(MissionInfo missionInfo)
    {
        for(int i = 0; i < missionInfo.starCount; i++) stars[i].sprite = obtainedStar;
        if(missionInfo.isMissionAvailable) {
            GetComponent<Image>().sprite = availableMissionSprite;
            this.missionNumber.color = Color.white;
        }
        this.missionNumber.text = missionInfo.missionNumber.ToString();
        this.missionTechName = missionInfo.missionTechName;
    }

    private void Start() {
        Setup(missionInfo);
    }

    public void OnClick()
    {
        SceneTransitionManager.SwitchToLevel(missionTechName);
    }
}

[Serializable] public struct MissionInfo{
    [Range(0, 3)]public int starCount;
    public bool isMissionAvailable;
    public int missionNumber;
    public string missionTechName;
}
