using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class BestScore : MonoBehaviour
{

    //public Text scoreText;
    //public Text bestScoreText;

    void Start()
    {
        float score = PlayerPrefs.GetFloat("score", 0);
        float bestScore = PlayerPrefs.GetFloat("bestScore", 0);


        if ((score < bestScore || bestScore < 1) && CoinsManager.HasWon())
        {
            PlayerPrefs.SetFloat("bestScore", score);
            bestScore = score;
        }
        //PlayerPrefs.SetFloat("bestScore", 74f);
        //scoreText.text = "Score: " + score.ToString("F1") + "s";
        TimeSpan ts = TimeSpan.FromSeconds(bestScore);
        string timeString = ts.ToString(@"mm\:ss");
        if (bestScore == 0) timeString = "--:--";
        GetComponent<TextMeshProUGUI>().text = timeString;
    }
}
