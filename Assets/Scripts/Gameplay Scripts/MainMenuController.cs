using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Canvas howToPlay, mainMenu;


    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void HowToPlay()
    {
        howToPlay.enabled = true;
        mainMenu.enabled = false;
    }
    public void MainMenu()
    {
        mainMenu.enabled = true;
        howToPlay.enabled = false;
    }
}
