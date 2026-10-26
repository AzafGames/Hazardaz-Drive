
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    // Reference to the player
    [SerializeField] private Transform player;

    // Camera 1 offset
    [SerializeField]
    private Vector3 cameraOffset = new Vector3(0f, 3f, -6f);

    // Camera 2 offset
    [SerializeField]
    private Vector3 camera2Offset = new Vector3(0f, 2f, 0.5f);

    // References to both cameras
    [SerializeField] private Camera camera1;
    [SerializeField] private Camera camera2;

    // True when Camera 2 is active
    private bool isCameraTwoActive = false;

    private void Start()
    {
        // Start with Camera 1 enabled
        SwitchCamera();
    }

    private void Update()
    {
        // Check whether C was pressed
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            // Toggle between the two cameras
            isCameraTwoActive = !isCameraTwoActive;

            // Apply the camera switch
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        // Enable only the selected camera
        camera1.enabled = !isCameraTwoActive;
        camera2.enabled = isCameraTwoActive;
    }

    private void LateUpdate()
    {
        // Follow the player using the active camera's offset
        if (isCameraTwoActive)
        {
            camera2.transform.position =
                player.position + camera2Offset;
        }
        else
        {
            camera1.transform.position =
                player.position + cameraOffset;
        }
    }
}
