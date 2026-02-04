using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 3;
    public static PlayerHealth Instance;

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

    public void PlayerHealthCounter(Collider2D other)
    {
        if (playerHealth > 0 && other.gameObject.CompareTag("Enemy"))
        {
            playerHealth -= PlayerController.Instance.damage;

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
