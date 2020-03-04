using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class Restart : MonoBehaviour
{
    public void restartgame()
    {
     //   UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        SceneManager.LoadScene ("mainScene");
    }

    public void exitgame()
    {
        Debug.Log ("Exit button pressed");
        Application.Quit ();
    }
}
