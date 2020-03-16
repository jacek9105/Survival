using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winscene : MonoBehaviour
{
    public void restartgame()
    {
        SceneManager.LoadScene("mainScene");
    }

    public void exitgame()
    {
        Debug.Log("Exit button pressed");
        Application.Quit();
    }

    public static bool lockCursor = false;


}

