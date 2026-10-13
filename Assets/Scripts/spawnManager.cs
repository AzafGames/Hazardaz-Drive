using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    // List of objects that can be spawned
    [SerializeField] private List<GameObject> spawnObjects = new List<GameObject>();

    // Available X positions for the three lanes
    private readonly int[] fixedPos = { -3, 0, 3 };

    // Time before spawning starts and time between each spawn
    private float startDelay = 1f;
    private float spawnInterval = 0.4f;

    // Set the Y and Z positions where objects will spawn
    private float spawnPosYofCollectibles = 1f;
    private float spawnPosYofObstacles = 0f;
    private float spawnPosZ = -60f;

    // Reference to the collisionChecker script
    private collisionChecker collisionChecker;

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
        if (collisionChecker.isGameOver)
        {
            return;
        }

        // Choose a random object from the list
        int objectIndex = Random.Range(0, spawnObjects.Count);

        // Choose a random lane
        int randomPosIndex = Random.Range(0, fixedPos.Length);

        if (spawnObjects[objectIndex].CompareTag("Collectible"))
        {
            // Set the position where the object will spawn
            Vector3 spawnPosition = new Vector3(
                fixedPos[randomPosIndex],
                spawnPosYofCollectibles,
                spawnPosZ
            );

            // Create the selected object at the spawn position
            GameObject spawnedObject = Instantiate(
                spawnObjects[objectIndex],
                spawnPosition,
                spawnObjects[objectIndex].transform.rotation
            );
        }else if (spawnObjects[objectIndex].CompareTag("Obstacle"))
        {
            // Set the position where the object will spawn
            Vector3 spawnPosition = new Vector3(
                fixedPos[randomPosIndex],
                spawnPosYofObstacles,
                spawnPosZ
            );

            // Create the selected object at the spawn position
            GameObject spawnedObject = Instantiate(
                spawnObjects[objectIndex],
                spawnPosition,
                spawnObjects[objectIndex].transform.rotation
            );
        }
    }
}