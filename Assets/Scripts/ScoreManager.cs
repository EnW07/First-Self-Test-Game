using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score;
    public int numberOfKilled;
    public int scoreForEnemy = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

    }

    public void addScore(int amount)
    {
        score += amount;
        Debug.Log("Your score: " + score);
    }

    public void killedAmount(int amount)
    {
        numberOfKilled += amount;
        Debug.Log("Killed amount:" + numberOfKilled);
    }
    



}
