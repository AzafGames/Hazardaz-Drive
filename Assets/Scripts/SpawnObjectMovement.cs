using UnityEngine;

public class SpawnObjectMovement : MonoBehaviour
{
    // Set how fast the object moves
    private float speed = 20f;

    // Set the Z position where the object will be destroyed
    private float maxRangeZ = -100f;

    // Reference to the collisionChecker script
    private collisionChecker collisionChecker;

    private void FixedUpdate()
    {
        // Stop moving if the game is over
        if (collisionChecker.isGameOver)
        {
            return;
        }

        // Move the object backward along the Z axis
        transform.position +=
            Vector3.back * speed * Time.fixedDeltaTime;

        // Destroy the object when it reaches the maximum distance
        if (transform.position.z <= maxRangeZ)
        {
            Destroy(gameObject);
        }
    }
}