using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int numberOfKilled;
    public int scoreForEnemy = 1;
    public TextMeshProUGUI scoreText;

   
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void KilledAmount(int amount)
    {
        numberOfKilled += amount;
    }
    



}
