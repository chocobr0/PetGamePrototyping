using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    const string glyphs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public char[] warpedChars;
    public Text currentCompliment;
    private string compliment;
    private string[] complimentList = 
    {
     "BELIEVE IN YOURSELF",
     "KEEP GOIN !!!!!",
     "HEY! KEEP ON GOING !!!!",
     "YOUVE GOT WHAT IT TAKES !!!",
     "YOUVE COME SO FAR !!!",
     "LETS FRIGGIN GO",
     "HI !!!!!!",
     "SMILE =)",
     "SENDING YA LUV SO KEEP GOING",
     "YOURE DOING GREAT",
     "TRUST YOUR UNIQUE PROCESS",
     "DONT CHANGE FOR ANYBODY",
     "EVERYTHING HAPPENS FOR A REASON",
     "DONT GIVE UP",
     "YOU ARE AWESOME",
     "YOU ARE ACCOMPLISHING SO MANY GREAT THINGS",
     "NO ONE CAN REPLICATE YOUR JOURNEY",
     "THIS JOURNEY WAS CURATED JUST FOR YOU AND ONLY YOU",
     "DONT CHANGE FOR ANYONE",
     "KEEP GOOOOOOOOOING",
     "I HOPE YOU KNOW YOU ARE ICONIC",
     "YOU ARE ON THE RIGHT TRACK",
     "YOUR LIFE IS YOUR RESPONSIBILITY AND NO ONE ELSES",
     "WE CAN LEARN AND GROW FROM EACH OTHER",
     "THIS JOURNEY WAS SPECIALLY CURATED FOR JUST YOU",
     "YOU. ARE. A. QUEEN.",
     "YOU ARE NOT ALONE",
     "STAY STRONG",
     "STAY EMPOWERED",
     "EMBRACE YOURSELF AND KEEP MOVING",
     "BELIVE IN YOURSELF BECAUSE YOU ARE GREAT",
     "DONT WORRY YOU GOT IT",
     "HAVE FAITH YOU WILL GET FAR IN THIS JOURNEY",
     "GOOOOOOOOOO AND CHANGE THE WORLD",
     "DONT WORRY YOU GOT IT",
     "YOU CANT GIVE UP NOW",
     "YOU. CAN. DO. IT.",
     "KEEP ON DOIN YOU DOE",
     "YOU CAN DO ANYTHING YOU SET YOUR HEART TO",
     "ITS A BRAND NEW DAY SO KEEP PUSHING",
     "DONT EVER GIVE UP ON YOUR DREAMS",
     "KEEP CHASING YOUR DREAMS"
     };
    private Transform playerTransform;
    private Transform demonTransform;
    private Renderer demonRenderer;
    private CanvasGroup bubbleVisibility;
    private float distanceBetweenDemonAndPlayer;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        demonTransform = GameObject.FindGameObjectWithTag("Kate").GetComponent<Transform>();
        demonRenderer = GameObject.FindGameObjectWithTag("Kate").GetComponent<Renderer>();
        bubbleVisibility = GetComponent<CanvasGroup>();
    }   

    void Update()
    {
        if (demonRenderer.isVisible)
        {
            bubbleVisibility.alpha = 1;
        }
        else
        {
            bubbleVisibility.alpha = 0;
            compliment = ComplimentChooser();
        }

        if (distanceBetweenDemonAndPlayer < 4)
        {
            CreateSpamText();
            compliment = ComplimentChooser();
        }
        else
        {
            currentCompliment.text = compliment;
        }

        distanceBetweenDemonAndPlayer = (demonTransform.position - playerTransform.position).magnitude;
    }

    void CreateSpamText()
    {
        warpedChars = new char[70];
        for (int i = 0; i < warpedChars.Length; i++)
        {
            warpedChars[i] = glyphs[Random.Range(0, glyphs.Length)];
        }
        string warpedScoreText = new string(warpedChars);
        currentCompliment.text = warpedScoreText;
    }

    string ComplimentChooser()
    {
        string choice;
        choice = complimentList[Random.Range(0, complimentList.Length)];
        return choice;
    }
}
