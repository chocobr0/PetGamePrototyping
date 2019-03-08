using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    const string glyphs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!?";
    public char[] warpedChars;
    public Text scoreText;
    public Text hiScoreText;
    public float scoreCount;
    public float hiScoreCount;
    public float pointsPerSecond;
    public bool scoreIncreasing;
    private Kate demonApproachesAt;

    void Start()
    {
        demonApproachesAt = FindObjectOfType<Kate>();

        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    void Update()
    {
        if(scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
            PlayerPrefs.SetFloat("CurrentScore", scoreCount);
        }

        if(scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }

        if(!DemonIsNear())
        {
            warpedChars = new char[6];
            for (int i = 0; i < warpedChars.Length; i++)
            {
                warpedChars[i] = glyphs[Random.Range(0, glyphs.Length)];
            }
            string warpedScoreText = new string(warpedChars);
            scoreText.text = "! " + warpedScoreText + " !";
            hiScoreText.text = "! " + warpedScoreText + " !";
        }
        else
        {
            scoreText.text = "SCORE " + Mathf.Round(scoreCount);
            hiScoreText.text = "HI-SCORE " + Mathf.Round(hiScoreCount);
        }
    }

    bool DemonIsNear()
    {
        if(demonApproachesAt.seperationDistance < 4)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
