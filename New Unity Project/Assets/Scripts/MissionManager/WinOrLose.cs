using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;
public class WinOrLose : MonoBehaviour
{

    public string _nameScene;
    public GameObject UiWin;

    public GameObject UIEndGame;

    public GameObject UILose;

    public GameObject[] Stars;

    public void Lose()
    {
        UILose.SetActive(true);
        UIEndGame.SetActive(true);
        //SampleScene
    }

    public void Win(int countStars)
    {
        Debug.Log(countStars);
        UIEndGame.SetActive(true);
        UiWin.SetActive(true);
        //Debug.Log(countStars);
        for(int i=0;i<countStars;i++)
        {
            Stars[i].SetActive(true);
        }
        //SceneTransitionManager.SwitchToLevelSync("SampleScene");
        //UILose.SetActive(false);
    }


    public void Restart()
    {
       SceneManager.LoadScene(_nameScene);
    }
    public void Menu()
    {
       SceneManager.LoadScene("Main Menu");
    }

}
