using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public int score;
    public Text scoreTeksti;

    void Start()
    { 
        score = PlayerPrefs.GetInt("score", 0);
        PlayerPrefs.SetInt("score", 0);
    }

    void Update()
    {
        scoreTeksti.text = score.ToString();

        if (Input.GetKeyDown("space"))
        {
            score++;
        }
    }

    public void AddScore()
    {
        score++;
        PlayerPrefs.SetInt("score", score);
    }

}
