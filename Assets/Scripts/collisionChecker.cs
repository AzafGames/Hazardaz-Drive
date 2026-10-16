using UnityEngine;

public class collisionChecker : MonoBehaviour
{
    // Tracks if the game is over
    public static bool isGameOver;

    private GameManager gameManager;

    // Keeps track of the player's score
    public static float score;

    // Keeps track of the car's current health
    public static float Carhealth;

    // Particle effects for explosions and collecting items
    public ParticleSystem explosionEffect;
    public ParticleSystem coinCollectEffect;

    // Audio components for sound effects
    public AudioSource audioSource;
    public AudioClip coinCollectSound;
    public AudioClip explosionSound;

    private void Awake()
    {
        // Reset game stats when the scene starts
        isGameOver = false;
        score = 0;
        Carhealth = 100;

        // Get the AudioSource component on this object
        audioSource = GetComponent<AudioSource>();
    }

    // Runs when the car enters a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Do nothing if the game is already over
        if (isGameOver)
        {
            return;
        }

        // If we hit a collectible (coin)
        if (other.gameObject.CompareTag("Collectible"))
        {
            // Remove the coin from the game
            Destroy(other.gameObject);

            // Play collection particle effect
            coinCollectEffect.Play();

            // Play coin sound effect
            audioSource.PlayOneShot(coinCollectSound, 1.0f);

            // Add 1 to the score
            score++;
        }
        // If we hit an obstacle
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            // Remove the obstacle from the game
            Destroy(other.gameObject);

            // Play explosion particle effect
            explosionEffect.Play();

            // Play explosion sound effect
            audioSource.PlayOneShot(explosionSound, 1.0f);

            // Reduce car health by 25
            Carhealth -= 25;

            // If health drops to 0 or below, end the game
            if (Carhealth <= 0)
            {
                isGameOver = true;
            }
        }
        // If we hit a power-up
        else if (other.gameObject.CompareTag("Health"))
        {
            // Heal the car if health is below maximum (100)
            if (Carhealth < 100)
            {
                Carhealth += 25;
            }

            // Remove the power-up from the game
            Destroy(other.gameObject);
        }

        // Reset health if the game is over and the restart button was clicked
        if (Carhealth <= 0 && GameManager.isRestartButtonClicked)
        {
            Carhealth = 100;
        }
    }
}