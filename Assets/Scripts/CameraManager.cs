
using UnityEngine;
using UnityEngine.InputSystem;

public class cameraManager : MonoBehaviour
{
    // Reference to the player
    [SerializeField] private Transform player;

    // Offset position for Camera 1
    [SerializeField]
    private Vector3 cameraOffset =
        new Vector3(0f, 3f, -6f);

    // Offset position for Camera 2
    [SerializeField]
    private Vector3 camera2Offset =
        new Vector3(0f, 2f, 0.5f);

    // References to both cameras
    [SerializeField] private Camera camera1;
    [SerializeField] private Camera camera2;

    // Track which camera is active
    private bool isCameraOneActive = true;
    private bool isCameraTwoActive = false;

    private void Start()
    {
        // Set the initial camera
        SwitchCamera();
    }

    private void Update()
    {
        // Switch cameras when the C key is pressed
        if (Keyboard.current != null &&
            Keyboard.current.cKey.wasPressedThisFrame)
        {
            // Toggle the active camera
            isCameraOneActive = !isCameraOneActive;
            isCameraTwoActive = !isCameraTwoActive;

            // Apply the camera switch
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        // Enable or disable camera rendering only
        camera1.enabled = isCameraOneActive;
        camera2.enabled = isCameraTwoActive;
    }

    private void LateUpdate()
    {
        // Move the active camera to follow the player
        if (isCameraOneActive)
        {
            camera1.transform.position =
                player.position + cameraOffset;
        }
        else if (isCameraTwoActive)
        {
            camera2.transform.position =
                player.position + camera2Offset;
        }
    }
}
