using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    public Vector3 borderMax = new Vector3(-6, 3.5f, 0);
    public Vector3 borderMin = new Vector3(-6, -3.5f, 0);

    private PlayerHealth playerHealthScript;
    private ScoreManager scoreManager;
    private BossHealth bossHealthScript;
    private GameManager gameManager;
    private PlayerController playerController;


    private void Start()
    {
        playerHealthScript = FindFirstObjectByType<PlayerHealth>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
        bossHealthScript = FindFirstObjectByType<BossHealth>();
        gameManager = FindFirstObjectByType<GameManager>();
        playerController = FindFirstObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y >= borderMax.y)
        {
            transform.position = borderMax;
        }
        else if (gameObject.transform.position.y <= borderMin.y)
        {
            transform.position = borderMin;
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("Player"))
        {
            gameManager.TakeDamage(playerController.damage);
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
