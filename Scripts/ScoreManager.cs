using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    const string glyphs = "!?ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    public char[] warpedScoreChars = new char[10];
    public Text scoreText;
    public Text hiScoreText;
    public float scoreCount;
    public float hiScoreCount;
    public float pointsPerSecond;
    public bool scoreIncreasing;
    private Kate demonApproachesAt;

    // Use this for initialization
    void Start()
    {
        demonApproachesAt = FindObjectOfType<Kate>();

        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if(scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }

        if(!DemonIsNear())
        {
            // Random string generator
            for (int i = 0; i < warpedScoreChars.Length; i++)
            {
                warpedScoreChars[i] = glyphs[Random.Range(0, glyphs.Length)];
            }
            string warpedScoreText = new string(warpedScoreChars);
            scoreText.text = "!" + warpedScoreText + "!";
            hiScoreText.text = "!" + warpedScoreText + "!";
        }
        else
        {
            scoreText.text = "SCORE " + Mathf.Round(scoreCount);
            hiScoreText.text = "HI-SCORE " + Mathf.Round(hiScoreCount);
        }
    }

    // Is demon close to player?
    bool DemonIsNear()
    {
        if(demonApproachesAt.seperationDistance < 4) //!!! REFACTOR TO BE MORE DYNAMIC !!!
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
