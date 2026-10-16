
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    // Movement speed of the player
    private float speed = 15f;

    // Input Action for keyboard/controller controls
    public InputAction moveKey;

    // Stores keyboard/controller input
    private Vector2 moveAction;

    // Stores UI button movement input
    // -1 = Left, 0 = Stop, +1 = Right
    private float uiMoveInput;

    // Left and right movement limit
    private float xRange = 6.7f;

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

        // Stop movement if the game has not started
        // or the game is over
        if (!GameManager.isStartButtonClicked ||
            collisionChecker.isGameOver)
        {
            return;
        }

        // Combine keyboard input with UI button input
        float horizontalInput = moveAction.x + uiMoveInput;

        // Keep input between -1 and 1
        horizontalInput = Mathf.Clamp(
            horizontalInput, -1f, 1f
        );

        // Move the player horizontally
        float movement = horizontalInput * speed * Time.deltaTime;

        transform.Translate(
            Vector3.right * movement,
            Space.World
        );

        // Keep the player within X-axis boundaries
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(
            position.x, -xRange, xRange
        );

        transform.position = position;
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

    // Called when Left/Right button movement stops
    public void StopMoving()
    {
        uiMoveInput = 0f;
    }
}
