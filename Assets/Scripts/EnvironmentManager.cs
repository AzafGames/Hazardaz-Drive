using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    // References to the three road segments used for endless scrolling
    [SerializeField] private Transform road1;
    [SerializeField] private Transform road2;
    [SerializeField] private Transform road3;

    // Speed at which the roads move backward
    [SerializeField] private float speed = 15f;

    // Length of each road section and the limit before a road is recycled
    [SerializeField] private float segmentLength = 49f;
    [SerializeField] private float maxRangeZ = -45f;

    // Reference to check if the game is over
    private collisionChecker collisionChecker;

    void Update()
    {
        // Stop moving if the game is over
        if (collisionChecker.isGameOver)
        {
            return;
        }

        // Move all three road pieces backward continuously
        MoveRoad(road1);
        MoveRoad(road2);
        MoveRoad(road3);

        // Check if any road needs to loop back to the front
        RecycleRoad(road1);
        RecycleRoad(road2);
        RecycleRoad(road3);
    }

    // Helper method to move a specific road backward in world space
    void MoveRoad(Transform road)
    {
        road.Translate(
            Vector3.back * speed * Time.deltaTime,
            Space.World
        );
    }

    // Helper method to teleport a road to the front once it goes past the threshold
    void RecycleRoad(Transform road)
    {
        // Check if the road has passed the boundary
        if (road.position.z <= maxRangeZ)
        {
            // Find which road is currently furthest ahead
            float frontZ = Mathf.Max(
                road1.position.z,
                road2.position.z,
                road3.position.z
            );

            Vector3 newPosition = road.position;

            // Move this road right in front of the furthest road
            newPosition.z = frontZ + segmentLength;

            road.position = newPosition;
        }
    }
}