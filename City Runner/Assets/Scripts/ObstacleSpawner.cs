using UnityEngine;
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab1;
    public GameObject obstaclePrefab2;

    private Vector3[] positions;
    private Vector3 firstPos;
    private Vector3 secondPos;
    private Vector3 thirdPos;

    private float speed = 5f;
    private float speedIncreaseInterval = 60f;
    private float timeSinceLastIncrease = 0f;
    private float timeSinceLastSpawn = 0f;
    private float spawnInterval = 2f;

    public ObstacleSpawner()
    {
        firstPos = new Vector3(3f, 0f, 18f);
        secondPos = new Vector3(0f, 0f, 18f);
        thirdPos = new Vector3(-3f, 0f, 18f);
        positions = new Vector3[] { firstPos, secondPos, thirdPos };
    }

    void Update()
    {
        // Spawn obstacle prefab
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            timeSinceLastSpawn -= spawnInterval;
            SpawnObstacle();
        }

        // Increase obstacle speed
        timeSinceLastIncrease += Time.deltaTime;
        if (timeSinceLastIncrease >= speedIncreaseInterval)
        {
            timeSinceLastIncrease -= speedIncreaseInterval;
            speed += 1f;
        }
    }

    void SpawnObstacle()
    {
        // Choose random position to spawn
        int randomPosIndex = Random.Range(0, positions.Length);
        Vector3 spawnPos = positions[randomPosIndex];

        // Choose random obstacle prefab to spawn
        GameObject obstaclePrefab;
        if (Random.value < 0.5f)
        {
            obstaclePrefab = obstaclePrefab1;
        }
        else
        {
            obstaclePrefab = obstaclePrefab2;
        }

        // Spawn obstacle prefab
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        obstacle.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -speed);

        // Destroy obstacle after 5 seconds
        Destroy(obstacle, 5f);
    }
}
