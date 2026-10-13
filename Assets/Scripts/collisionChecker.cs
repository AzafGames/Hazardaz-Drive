using UnityEngine;

public class collisionChecker : MonoBehaviour
{
    // Global flag to track if the game is over across all scripts
    public static bool isGameOver;

    private GameManager gameManager;

    // Keeps track of the total collected points (persists across collisions)
    public static float score;

    public static float Carhealth;

    // Particle effect references assigned via the Inspector
    public ParticleSystem explosionEffect;
    public ParticleSystem coinCollectEffect;

    // Audio components for playing sound effects
    public AudioSource audioSource;
    public AudioClip coinCollectSound;
    public AudioClip explosionSound;


    private void Awake()
    {
        // Reset game state when scene starts/restarts
        isGameOver = false;
        score = 0;
        Carhealth = 100;

        // Get and store the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }


    // Runs automatically whenever this GameObject collides with another 3D object
    private void OnCollisionEnter(Collision other)
    {
        // Stop if game is over
        if (isGameOver)
        {
            return;
        }

        // Check for collectible
        if (other.gameObject.CompareTag("Collectible"))
        {
            // Remove the collectible object from the scene
            Destroy(other.gameObject);

            // Play the visual collection particle effect
            coinCollectEffect.Play();

            // Play the coin pickup audio clip once at full volume
            audioSource.PlayOneShot(coinCollectSound, 1.0f);

            // Increase point count by 1
            score++;
        }

        // Check for obstacle
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            // Destroy the obstacle object
            Destroy(other.gameObject);

            // Trigger the explosion visual particle effect
            explosionEffect.Play();

            // Play the explosion sound effect at full volume
            audioSource.PlayOneShot(explosionSound, 1.0f);

            
            Carhealth -= 100;
        }

        if (Carhealth <= 0)
        {
            isGameOver = true;

        }
        
        if (Carhealth <= 0 && GameManager.isRestartButtonClicked)
        {

            Carhealth = 100;
        }
        
        
    }
}