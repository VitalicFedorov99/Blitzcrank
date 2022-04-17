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
    private string missionTechName;

    private void Setup(int starsCount, bool isMissionAvailable, int missionNumber, string missionTechName)
    {
        for(int i = 0; i < starsCount; i++) stars[i].sprite = obtainedStar;
        if(isMissionAvailable) {
            GetComponent<Image>().sprite = availableMissionSprite;
            this.missionNumber.color = Color.white;
        }
        this.missionNumber.text = missionNumber.ToString();
        this.missionTechName = missionTechName;
    }

    public void OnClick()
    {
        SceneTransitionManager.SwitchToLevel(missionTechName);
    }
}
