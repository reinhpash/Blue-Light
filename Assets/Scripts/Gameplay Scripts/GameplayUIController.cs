using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    public Text waveText;
    public Text scoreText;
    public Text rocketText;
    public static GameplayUIController instance;

    private int waveValue;
    private double scoreValue;
    private int score = 100;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SetPlayerHealth()
    {
        //PlayerHealth.value =;
    }

    public void SetRocketText(int rocketAmount)
    {
        rocketText.text = "ROCKET: " + rocketAmount;
    }

    public void SetWave()
    {
        waveValue++;
        waveText.text = "WAVE: " + waveValue;
    }

    public void SetScore(int i)
    {
        // 1 = horizontal, 2 = random, 3 = pawn, 4 = meteor
        if (i == 1)
        {
            scoreValue += score * 1.25;
        }
        else if (i == 2)
        {
            scoreValue += score * 1.5;
        }
        else if (i == 3 || i == 4)
        {
            scoreValue += score;
        }

        scoreText.text = "SCORE: " + (int)scoreValue;

    }

    public int GetWaveCount()
    {
        return waveValue;
    }
    public int GetScoreCount()
    {
        return (int)scoreValue;
    }
}
