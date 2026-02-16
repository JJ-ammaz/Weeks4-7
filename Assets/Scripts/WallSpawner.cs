using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    // Wall prefab (drag in Inspector)
    public GameObject wallPrefab;

    // Spawn settings
    private float spawnTimer = 0f;
    private float spawnInterval = 3f; // spawn every 3 seconds

    private float spawnX = 10f;
    private float minHeight = -3f;
    private float maxHeight = 3f;
    void Start()
    {

    }

    void Update()
    {
        // Timer counts up
        spawnTimer += Time.deltaTime;

        // When timer reaches interval spawn
        if (spawnTimer >= spawnInterval)
        {
            SpawnWall();
            spawnTimer = 0f; // reset timer
        }
    }

    void SpawnWall()
    {
        // Random Y pos
        float randomY = Random.Range(minHeight, maxHeight);

        // Spawn pos
        Vector3 spawnPos = new Vector3(spawnX, randomY, 0f);

        // wall prefab
        Instantiate(wallPrefab, spawnPos, Quaternion.identity);
    }
}