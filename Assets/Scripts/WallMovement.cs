using UnityEngine;

public class WallMovement : MonoBehaviour
{
    // Reference to the single wall
    public GameObject wall;

    // Wall spawn settings
    private float spawnX = 10f;
    private float minHeight = -3f;
    private float maxHeight = 3f;

    // Wall movement PUBLIC so slider thingysd can change 
    public float moveSpeed = 3f;
    private float resetX = -10f;

    void Start()
    {
        ResetWall();
    }

    void Update()
    {
        // Move wall
        wall.transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // If wall goes off left side reset it
        if (wall.transform.position.x < resetX)
        {
            ResetWall();
        }
    }

    // PUBLIC so restart button can do
    public void ResetWall()
    {
        // Random Y position
        float randomY = Random.Range(minHeight, maxHeight);

        // Put wall at right side with random height
        wall.transform.position = new Vector3(spawnX, randomY, 0f);
    }
}