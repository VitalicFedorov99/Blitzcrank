using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLose : MonoBehaviour
{

    public GameObject UiWin;

    public GameObject UILose;

    public void Lose()
    {
        UiWin.SetActive(true);
    }

    public void Win()
    {
        UILose.SetActive(false);
    }


}
