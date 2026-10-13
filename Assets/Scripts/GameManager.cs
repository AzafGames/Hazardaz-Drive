using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Reference to the score text
    [SerializeField] private TextMeshProUGUI scoreText;

    // Reference to the game over text
    [SerializeField] private TextMeshProUGUI gameOverText;

    // Reference to the health text
    [SerializeField] private TextMeshProUGUI healthText;

    // References to the game buttons
    [SerializeField] private Button startButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    // Reference to the PlayerMovement script
    [SerializeField] private playerMovement player;

    // Store the current game button states
    public static bool isStartButtonClicked;
    public static bool isPauseButtonClicked;
    public static bool isRestartButtonClicked;

    private void Awake()
    {
        // Pause the game when it starts
        Time.timeScale = 0f;

        // Reset all game button states
        isStartButtonClicked = false;
        isPauseButtonClicked = false;
        isRestartButtonClicked = false;

        // Show the score, start, and exit buttons
        scoreText.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);

        // Hide the other UI elements
        gameOverText.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);

        // Display the initial score and health
        UpdateScoreUI();
        UpdateHealthUI();
    }

    private void Update()
    {
        // Update the score and health displays
        UpdateScoreUI();
        UpdateHealthUI();

        // Check if the game is over
        if (collisionChecker.isGameOver)
        {
            // Show the game over message and restart button
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);

            // Hide the pause and resume buttons
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(false);

            // Show the exit button
            exitButton.gameObject.SetActive(true);

            // Hide the movement buttons
            leftButton.gameObject.SetActive(false);
            rightButton.gameObject.SetActive(false);
        }
    }

    private void UpdateScoreUI()
    {
        // Display the current score
        scoreText.text = "Score: " + collisionChecker.score;
    }

    private void UpdateHealthUI()
    {
        // Display the current car health
        healthText.text = "Health: " + collisionChecker.Carhealth + "%";
    }

    public void StartGame()
    {
        // Update the game button states
        isStartButtonClicked = true;
        isPauseButtonClicked = false;
        isRestartButtonClicked = false;

        // Start the game
        Time.timeScale = 1f;

        // Update the button visibility
        startButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        // Show the movement buttons
        leftButton.gameObject.SetActive(true);
        rightButton.gameObject.SetActive(true);
    }

    public void LeftButton()
    {
        // Tell the player to move left
        player.MoveLeft();
    }

    public void RightButton()
    {
        // Tell the player to move right
        player.MoveRight();
    }

    public void StopButton()
    {
        // Tell the player to stop moving
        player.StopMoving();
    }

    public void PauseGame()
    {
        // Mark the game as paused
        isPauseButtonClicked = true;

        // Pause the game
        Time.timeScale = 0f;

        // Update the button visibility
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(true);

        // Stop the player's movement
        player.StopMoving();
    }

    public void ResumeGame()
    {
        // Mark the game as unpaused
        isPauseButtonClicked = false;

        // Resume the game
        Time.timeScale = 1f;

        // Update the button visibility
        resumeButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        // Mark that the restart button was clicked
        isRestartButtonClicked = true;

        // Make sure the game is running before reloading
        Time.timeScale = 1f;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        // Close the game application
        Application.Quit();
    }
}