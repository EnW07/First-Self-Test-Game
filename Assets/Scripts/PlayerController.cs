using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    private float verticalInput;
    public GameObject bulletPrefab;
    public int damage = 1;
    public Vector3 bulletOffset;
    public bool canShoot = true;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {

        bulletOffset = new Vector3(-4.5f, transform.position.y, transform.position.z);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.R))
        {
            sizeIncrease();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canShoot == true)
        {
            shootBullets();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            gameManager.Heal(5);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            gameManager.TakeDamage(10);
            gameManager.CheckIfDead(gameObject);
        }


    }

    void sizeIncrease()
    {
        Vector3 newScale = new Vector3(2, 2, 2);
        transform.localScale = newScale;
    }



    void shootBullets()
    {
        if(canShoot == true)
        {
            Instantiate(bulletPrefab, bulletOffset, bulletPrefab.transform.rotation);
            canShoot = false;
        }
        
        canShoot = true;
    }



}
