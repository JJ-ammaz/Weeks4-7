using UnityEngine;

public class WallMovement : MonoBehaviour
{
    // Wall movement PUBLIC so slider can change 
    public static float moveSpeed = 3f;

    // ADDED - timer to destroy wall
    private float lifeTimer = 0f;
    private float lifeTime = 10f; // destroy after 5 seconds
    void Start()
    {

    }

    void Update()
    {
        // Move wall left
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Timer counts up
        lifeTimer += Time.deltaTime;

        // Destroy wall after lifeTime seconds
        if (lifeTimer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}