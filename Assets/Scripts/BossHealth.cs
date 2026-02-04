using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int bossHealth = 3;
    public static BossHealth Instance;

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

    public void BossHealthCounter(Collider2D other)
    {
        if (bossHealth > 0)
        {
            bossHealth -= PlayerController.Instance.damage;
            
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
