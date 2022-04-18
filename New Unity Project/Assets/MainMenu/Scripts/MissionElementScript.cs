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
    [SerializeField] private string missionTechName;

    [SerializeField] private bool isMissiaActiv=false;
    [SerializeField] private int number;

    public void Setup(int starsCount, bool isMissionAvailable)
    {
        for(int i = 0; i < starsCount; i++) stars[i].sprite = obtainedStar;
        if(isMissionAvailable) {
            GetComponent<Image>().sprite = availableMissionSprite;
            this.missionNumber.color = Color.white;
            isMissiaActiv=isMissionAvailable;

        }
        this.missionNumber.text = number.ToString();
       
    }

    public void OnClick()
    {
        if(isMissiaActiv==true)
        SceneTransitionManager.SwitchToLevelSync(missionTechName);
    }
}
