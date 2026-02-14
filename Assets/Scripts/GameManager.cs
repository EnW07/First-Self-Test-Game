using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    private GameObject player;
    public Button startButton;
    public TextMeshProUGUI titleText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            Heal(5);
        }else if(Input.GetKeyDown(KeyCode.V))
        {
            takeDamage(10);
            checkIfDead(player);
        }

    }


    private void takeDamage(float healthDamage)
    {
        healthAmount -= healthDamage;
        healthBar.fillAmount = healthAmount / 100f;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
    }


    private void Heal(float healthHeal)
    {
        healthAmount += healthHeal;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }


    private void checkIfDead(GameObject player)
    {
        if(healthAmount <= 0)
        {
            healthAmount = 0;
            Destroy(player);
            SceneManager.LoadScene(0);
        }
    }

}
