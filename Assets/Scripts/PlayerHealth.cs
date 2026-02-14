using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 3;
    private PlayerController playerController;


    public void PlayerHealthCounter(Collider2D other)
    {
        if (playerHealth > 0 && other.gameObject.CompareTag("Enemy"))
        {
            playerHealth -= playerController.damage;

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
