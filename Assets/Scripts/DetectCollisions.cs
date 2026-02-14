using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    public Vector3 borderMax = new Vector3(-6, 3.5f, 0);
    public Vector3 borderMin = new Vector3(-6, -3.5f, 0);

    private PlayerHealth playerHealthScript;
    private ScoreManager scoreManager;
    private BossHealth bossHealthScript;


    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y >= borderMax.y)
        {
            Debug.Log("yo");
            transform.position = borderMax;
        }
        else if (gameObject.transform.position.y <= borderMin.y)
        {
            Debug.Log("youltra");
            transform.position = borderMin;
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("Player"))
        {
            playerHealthScript.PlayerHealthCounter(other);
        }
        else if (other.gameObject.CompareTag("Bullet") && !gameObject.CompareTag("Player"))
        {
            
            if (gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                scoreManager.AddScore(scoreManager.scoreForEnemy);
                scoreManager.KilledAmount(1);
            }
            else if (gameObject.CompareTag("Boss"))
            {
                bossHealthScript.BossHealthCounter(other);
            }
        }
        else if(other.gameObject.CompareTag("BorderLeft"))
        {
            Destroy(gameObject);
            Debug.Log("Game over!");
        }   
    }
}
