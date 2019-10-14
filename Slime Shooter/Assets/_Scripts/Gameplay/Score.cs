using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;
    
    [SerializeField] private Tries tries;
    private int triesScore;

    public void AddScore()
    {
        score += 100;
        scoreText.text = score.ToString();
        triesScore += 100;

        if(PlayerPrefs.GetInt("Score") < score)
        {
            PlayerPrefs.SetInt("Score", score);
        }

        if(triesScore >= 5000)
        {
            triesScore -= 5000;
            tries.AddTry();
        }
    }
}
