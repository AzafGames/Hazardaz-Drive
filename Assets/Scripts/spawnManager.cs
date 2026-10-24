using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    // List of objects that can be spawned
    [SerializeField] private List<GameObject> collectibleObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> obstacleObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> powerUpObjects = new List<GameObject>();

    // Available X positions for the three lanes
    private readonly int[] fixedPos = { -5, 0, 5 };

    // Time before spawning starts and time between each spawn
    private float startDelay = 0.5f;
    private float spawnInterval = 0.4f;

    // Set the Y and Z positions where objects will spawn
    private float spawnPosYofCollectibles = 1f;
    private float spawnPosYofObstacles = 0f;
    private float spawnPosZ = 10;

    // Reference to the collisionChecker script
    private CollisionManager collisionManager;

    private void OnEnable()
    {
        // Start spawning objects repeatedly
        InvokeRepeating(nameof(SpawnRandomObject), startDelay, spawnInterval);
    }

    private void OnDisable()
    {
        // Stop spawning objects when this script is disabled
        CancelInvoke(nameof(SpawnRandomObject));
    }

    private void SpawnRandomObject()
    {
        // Stop spawning if the game is over
        if (CollisionManager.isGameOver)
        {
            return;
        }

        // Choose a random lane
        int randomPosIndex = Random.Range(0, fixedPos.Length);

        int spawnProbabilityRoll = Random.Range(0, 100);

        if (spawnProbabilityRoll < 70)
        {
            // Set the position where the object will spawn
            Vector3 spawnPosition = new Vector3(
                fixedPos[randomPosIndex],
                spawnPosYofCollectibles,
                spawnPosZ
            );

            // Pick a random collectible object to spawn
            int collectibleIndex = Random.Range(0, collectibleObjects.Count);
            GameObject collectiblePrefab = collectibleObjects[collectibleIndex];

            // Create the selected object at the spawn position
            Instantiate(
                collectiblePrefab,
                spawnPosition,
                collectiblePrefab.transform.rotation
            );
        }
        else if (spawnProbabilityRoll < 95)
        {
            // Set the position where the object will spawn
            Vector3 spawnPosition = new Vector3(
                fixedPos[randomPosIndex],
                spawnPosYofObstacles,
                spawnPosZ
            );

            // Pick a random obstacle object to spawn
            int obstacleIndex = Random.Range(0, obstacleObjects.Count);
            GameObject obstaclePrefab = obstacleObjects[obstacleIndex];

            // Create the selected object at the spawn position
            Instantiate(
                obstaclePrefab,
                spawnPosition,
                obstaclePrefab.transform.rotation
            );
        }
        else if (spawnProbabilityRoll >= 95)
        {
            // Set the position where the object will spawn
            Vector3 spawnPosition = new Vector3(
                fixedPos[randomPosIndex],
                spawnPosYofCollectibles,
                spawnPosZ
            );

            // Pick a random power-up object to spawn
            int powerUpIndex = Random.Range(0, powerUpObjects.Count);
            GameObject powerUpPrefab = powerUpObjects[powerUpIndex];

            // Create the selected object at the spawn position
            Instantiate(
                powerUpPrefab,
                spawnPosition,
                powerUpPrefab.transform.rotation
            );
        }
    }
}