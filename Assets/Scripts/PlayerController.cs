using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    private float verticalInput;
    public GameObject bulletPrefab;
    public int damage = 1;
    public static PlayerController Instance;
    public Vector3 bulletOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootBullets();
        }

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

    void sizeIncrease()
    {
        Vector3 newScale = new Vector3(2, 2, 2);
        transform.localScale = newScale;
    }



    void shootBullets()
    {
        Instantiate(bulletPrefab, bulletOffset, bulletPrefab.transform.rotation);
    }



}
