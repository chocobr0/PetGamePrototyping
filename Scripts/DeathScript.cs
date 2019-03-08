using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{
    private const string score = "Score: ";
    private const string highscore = "High Score: ";
    public Text currentScore;
    public Text highScore;
    public float currentScoreCount;
    public float hiScoreCount;

    void Start()
    {
        currentScore.text = score + Mathf.Round(PlayerPrefs.GetFloat("CurrentScore"));
        highScore.text = highscore + Mathf.Round(PlayerPrefs.GetFloat("HighScore"));
    }
    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }
}