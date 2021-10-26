using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverUIController : MonoBehaviour
{
    public static GameoverUIController instance;

    [SerializeField] private Canvas playerInfoCanvas, gameOverCanvas;
    [SerializeField] private Text gameoverScoreText;
    [SerializeField] private Text highScoreText;

    private int score;
    private int highScore;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void OpenGameOverPanel()
    {
        playerInfoCanvas.enabled = false;
        gameOverCanvas.enabled = true;

        score = GameplayUIController.instance.GetScoreCount();
        gameoverScoreText.text = "SCORE: " + score.ToString();

        //Calculate highscore
        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore").ToString();
        
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
