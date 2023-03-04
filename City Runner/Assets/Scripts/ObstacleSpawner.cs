using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefabA;
    public GameObject obstaclePrefabB;

    private Vector3[] positions;
    private Vector3 firstPos;
    private Vector3 secondPos;
    private Vector3 thirdPos;

    private float speed = 5f;
    private float speedIncreaseInterval = 20f;
    private float timeSinceLastIncrease = 0f;
    private float timeSinceLastSpawn = 0f;
    private float spawnInterval = 2f;
    public GameObject playerObject;
    private bool Ongoing = true;

    public ObstacleSpawner()
    {
        firstPos = new Vector3(3f, 0f, 18f);
        secondPos = new Vector3(0f, 0f, 18f);
        thirdPos = new Vector3(-3f, 0f, 18f);
        positions = new Vector3[] { firstPos, secondPos, thirdPos };
    }

    void Update()
    {
        PlayerController playerInfo = playerObject.GetComponent<PlayerController>();

        if(playerInfo.isTouched == false){Ongoing = true;}else Ongoing = false;

        if(Ongoing == true){
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
                timeSinceLastIncrease = 0;
                speed += 2f;
            }
        }
    }

    void SpawnObstacle()
    {
        // Choose two random positions to spawn obstacles
        int randomPosIndex1 = Random.Range(0, positions.Length);
        int randomPosIndex2 = (randomPosIndex1 + 1) % positions.Length; // Ensures the two positions are different
        Vector3 spawnPos1 = positions[randomPosIndex1];
        Vector3 spawnPos2 = positions[randomPosIndex2];

        // Choose random obstacle prefabs to spawn
        GameObject obstaclePrefab1;
        GameObject obstaclePrefab2;

        if (Random.value < 0.5f)
        {
            obstaclePrefab1 = obstaclePrefabA;
            obstaclePrefab2 = obstaclePrefabB;
        }
        else
        {
            obstaclePrefab1 = obstaclePrefabB;
            obstaclePrefab2 = obstaclePrefabA;
        }

        // Spawn obstacle prefabs
        GameObject obstacle1 = Instantiate(obstaclePrefab1, spawnPos1, Quaternion.identity);
        GameObject obstacle2 = Instantiate(obstaclePrefab2, spawnPos2, Quaternion.identity);

        // Set the velocity of the obstacles
        obstacle1.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -speed);
        obstacle2.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -speed);

        // Destroy the obstacles after 5 seconds
        Destroy(obstacle1, 5f);
        Destroy(obstacle2, 5f);
    }

    

}
