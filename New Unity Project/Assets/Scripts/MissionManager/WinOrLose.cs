using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;
public class WinOrLose : MonoBehaviour
{

    public string NameScene;
    public int CountLevel;

    public StaticData Data;
    public GameObject UiWin;

    public GameObject UIEndGame;

    public GameObject UILose;

    public GameObject[] Stars;

    private AudioSource _audio;

    private AudioClip _clipWin;

    private AudioClip _clipLose;
    private void Start() 
    {
        _audio=GetComponent<AudioSource>();
         AudioManager.GetAudioSource("EndLevel3",out _clipWin);
          AudioManager.GetAudioSource("RobotDeath1",out _clipLose);
           
    }
    public void Lose()
    {
        _audio.clip=_clipLose;
        _audio.Play();
        UILose.SetActive(true);
        UIEndGame.SetActive(true);
        //SampleScene
    }

    public void Win(int countStars)
    {
        _audio.clip=_clipWin;
        _audio.Play();
        Debug.Log(countStars);
        UIEndGame.SetActive(true);
        UiWin.SetActive(true);
        Debug.Log(countStars);
        for(int i=0;i<countStars;i++)
        {
            Stars[i].SetActive(true);
        }
        Data.SetLevelStars(CountLevel,countStars);
        //SceneTransitionManager.SwitchToLevelSync("SampleScene");
        //UILose.SetActive(false);
    }


    public void Restart()
    {
       SceneManager.LoadScene(NameScene);
    }
    public void Menu()
    {
       SceneManager.LoadScene("Main Menu");
    }

}
