using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int numberOfKilled;
    public int scoreForEnemy = 1;

   
    public void AddScore(int amount)
    {
        score += amount;
    }

    public void KilledAmount(int amount)
    {
        numberOfKilled += amount;
    }
    



}
