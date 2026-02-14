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

    public void TakeDamage(float healthDamage)
    {
        healthAmount -= healthDamage;
        healthBar.fillAmount = healthAmount / 100f;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
    }


    public void Heal(float healthHeal)
    {
        healthAmount += healthHeal;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }


    public void CheckIfDead(GameObject player)
    {
        if(healthAmount <= 0)
        {
            healthAmount = 0;
            Destroy(player);
            SceneManager.LoadScene(0);
        }
    }

}
