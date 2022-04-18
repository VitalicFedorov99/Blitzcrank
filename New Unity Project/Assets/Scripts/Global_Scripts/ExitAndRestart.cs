using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitAndRestart : MonoBehaviour
{
    public StaticData _data;
    public UpdaterInfo _updateInfo;

    public void Restart()
    {
        Debug.Log("рестарт");
        _data.SetupData();
        SceneManager.LoadScene("Main Menu");
        //_updateInfo.UpdateInfoMissia();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
