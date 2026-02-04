using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        



        if (gameObject.CompareTag("Player"))
        {
            PlayerHealth.Instance.PlayerHealthCounter(other);
        }
        else if (other.gameObject.CompareTag("Bullet") && !gameObject.CompareTag("Player"))
        {
            
            if (gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                ScoreManager.Instance.addScore(ScoreManager.Instance.scoreForEnemy);
                ScoreManager.Instance.killedAmount(1);
            }
            else if (gameObject.CompareTag("Boss"))
            {
                BossHealth.Instance.BossHealthCounter(other);
            }
        }
        else if(other.gameObject.CompareTag("BorderLeft"))
        {
            Destroy(gameObject);
            Debug.Log("Game over!");
        }   
    }
}
