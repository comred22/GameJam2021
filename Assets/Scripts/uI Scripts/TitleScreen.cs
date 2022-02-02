using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

    public string levelScene;
    public string creditsScene;
    public string controls;

    public void Awake()
    {
        AudioListener.pause = false;
        Time.timeScale = 1;
    }

    public void startGame()
    {
        SceneManager.LoadScene(levelScene);
    }

    public void showCredits()
    {
        SceneManager.LoadScene(creditsScene);
    }
    public void showControls()
    {
        SceneManager.LoadScene(controls);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
