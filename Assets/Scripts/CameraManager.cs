using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Reference to the player
    [SerializeField] private Transform player;

    // Distance between the player and camera
    [SerializeField] private Vector3 cameraOffset = new Vector3(0f, 3f, -6f);

    private void LateUpdate()
    {
        // Calculate the camera position
        Vector3 targetPosition = player.position + cameraOffset;

        // Follow the player
        transform.position = targetPosition;
    }
}