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
        // Stop movement if the game has not started or is over
        if (!GameManager.isStartButtonClicked || collisionChecker.isGameOver)
        {
            return;
        }

        // Get the current player position
        Vector3 newPosition = playerRb.position;

        // Move the player horizontally
        newPosition.x += moveInput.x * speed * Time.fixedDeltaTime;

        // Keep the player within the movement range
        newPosition.x = Mathf.Clamp(newPosition.x, -xRange, xRange);

        // Apply the new position
        playerRb.MovePosition(newPosition);
    }
}