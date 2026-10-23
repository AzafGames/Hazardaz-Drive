using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    // Movement settings
    private float speed = 15f;
    private float xRange = 6.7f;

    // Input system
    private InputSystem_Actions controls;
    private Vector2 moveInput;

    // Rigidbody for player movement
    private Rigidbody playerRb;

    private void Awake()
    {
        // Get Rigidbody and create controls
        playerRb = GetComponent<Rigidbody>();
        controls = new InputSystem_Actions();

    }

    private void OnEnable()
    {
        // Enable player controls
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        // Disable player controls
        controls.Player.Disable();

    }

    private void Update()
    {
        // Read movement input
        moveInput = controls.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Normalize the direction vector to prevent diagonal speeding
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, 0f).normalized;

        // Get the current position and calculate the new target position
        Vector3 newPosition = playerRb.position + moveDirection * speed * Time.fixedDeltaTime;

        // Keep the player within the movement range on the X axis
        newPosition.x = Mathf.Clamp(newPosition.x, -xRange, xRange);

        // Move the Rigidbody safely to the final clamped position
        playerRb.MovePosition(newPosition);
    }
}