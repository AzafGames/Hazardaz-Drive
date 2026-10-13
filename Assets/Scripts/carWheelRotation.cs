using UnityEngine;

public class carWheelRotation : MonoBehaviour
{
    // Wheel rotation speed
    private float rotationSpeed = 10f;

    // Reference to the collisionChecker script 
    private collisionChecker collisionChecker;

    // Reference to the GameManger script
    private GameManager gameManager;

    // Update is called once per frame
    private void Update()
    {

        // Check if the game is still running before executing movement
        if (!collisionChecker.isGameOver 
            && GameManager.isStartButtonClicked 
            && !GameManager.isPauseButtonClicked 
            && !GameManager.isRestartButtonClicked)
        {
            // Rotate the wheel around its local X-axis based on rotationSpeed
            transform.Rotate(rotationSpeed, 0, 0);
        }
    }
}