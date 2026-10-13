using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    // Movement speed of the player
    private float speed = 15f;

    // Input Action field to map controls
    // Example: WASD / Arrow keys
    public InputAction moveKey;

    // Stores keyboard/controller directional input
    private Vector2 moveAction;

    // Stores UI button movement input
    // -1 = Left
    //  0 = Stop
    // +1 = Right
    private float uiMoveInput;

    // Reference to the player's Rigidbody
    private Rigidbody rb;

    // Left and right movement limit along the X-axis
    private float xRange = 3.2f;

    // Reference to GameManager Script
    private GameManager gameManager;

    //Reference to collisionChecker Script
    private collisionChecker collisionChecker;

    private void Awake()
    {
        // Get Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        // Enable input action
        moveKey.Enable();
    }

    private void OnDisable()
    {
        // Disable input action
        moveKey.Disable();
    }

    private void Update()
    {
        // Read keyboard/controller input
        moveAction = moveKey.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Stop movement if the game has not started or is over
        if (!GameManager.isStartButtonClicked || collisionChecker.isGameOver)
        {
            return;
        }

        

        // Combine keyboard/controller input
        // with UI button input
        float horizontalInput = moveAction.x + uiMoveInput;

        // Keep the value between -1 and 1
        horizontalInput = Mathf.Clamp(horizontalInput, -1f, 1f);

        // Get current position
        Vector3 position = transform.position;

        // Apply horizontal movement
        position.x += speed * Time.fixedDeltaTime * horizontalInput;

        // Keep player inside X boundaries
        position.x = Mathf.Clamp(position.x, -xRange, xRange);

        // Move using Rigidbody physics
        rb.MovePosition(position);
    }

    // Called by GameManager when Left button is pressed
    public void MoveLeft()
    {
        uiMoveInput = -1f;
    }

    // Called by GameManager when Right button is pressed
    public void MoveRight()
    {
        uiMoveInput = 1f;
    }

    // Called by GameManager when Left/Right button is released
    public void StopMoving()
    {
        uiMoveInput = 0f;
    }
}