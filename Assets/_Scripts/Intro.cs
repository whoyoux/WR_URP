using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public int nextSceneIndex;
    public void SwitchScene()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
