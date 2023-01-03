using UnityEngine;
using UnityEngine.UI;

public class ScoresMainMenu : MonoBehaviour {

    public Text scoreText;
    public Text bestScoreText;

    void Start() {
        float score = PlayerPrefs.GetFloat("score", 0);
        float bestScore = PlayerPrefs.GetFloat("bestScore", 0);

        if(score > bestScore) {
            PlayerPrefs.SetFloat("bestScore", score);
            bestScore = score;
        }

        scoreText.text = "Score: " + score.ToString("F1") + "s";
        bestScoreText.text = "Best score: " + bestScore.ToString("F1") + "s";
    }
}
