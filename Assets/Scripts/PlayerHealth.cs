using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 3;
    private PlayerController playerController;
    private GameManager gameManager;

    private void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        gameManager = FindFirstObjectByType<GameManager>();
    }
    public void PlayerHealthCounter(Collider2D other)
    {
        if (playerHealth > 0 && other.gameObject.CompareTag("Enemy"))
        {

            Debug.Log("Damage! Player health" + (playerHealth));
            Destroy(other.gameObject);
            if (playerHealth == 0)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                Debug.Log("Game over!");
            }
        }
    }
}
