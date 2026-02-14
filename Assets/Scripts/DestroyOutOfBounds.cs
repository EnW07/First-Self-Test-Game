using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float borderX = 10;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > borderX)
        {
            Destroy(gameObject);
        }

    }
}
