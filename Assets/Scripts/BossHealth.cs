using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int bossHealth = 3;
    private PlayerController playerController;


    public void BossHealthCounter(Collider2D other)
    {
        if (bossHealth > 0)
        {
            bossHealth -= playerController.damage;
            
            Debug.Log("Damage! Boss health" + (bossHealth));
            Destroy(other.gameObject);
            if (bossHealth == 0)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                Debug.Log("Boss defeated!");
            }
        }
    }
}
