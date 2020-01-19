using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadSceneAsync("Main");
    }

    public void showHowToPlay()
    {
        SceneManager.LoadSceneAsync("HowToPlay");
    }

    public void showOptions()
    {

    }

    public void exit()
    {
        Application.Quit();
    }
}
