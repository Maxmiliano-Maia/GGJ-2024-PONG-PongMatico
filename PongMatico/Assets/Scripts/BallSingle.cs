using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallSingle : MonoBehaviour
{
    private Rigidbody2D rb;

    public float baseSpeed = 5f;
    public float maxSpeed = Mathf.Infinity;
    public float acceleration = 0.5f;
    public float currentSpeed { get; private set; }
    private AudioSource racketCollisionAudioSource;  // AudioSource for racket collisions
    private AudioSource otherCollisionAudioSource;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        racketCollisionAudioSource = transform.Find("Player Paddle").GetComponent<AudioSource>();
        otherCollisionAudioSource = transform.Find("Player Paddle").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves the racket
        if (collision.gameObject.CompareTag("Racket"))
        {
            PlayRacketCollisionSound();
        }
        else
        {
            // For collisions with other objects
            PlayOtherCollisionSound();
        }
    }

    private void PlayRacketCollisionSound()
    {
        // Check if an audio clip is assigned for racket collisions and play the sound
        if (racketCollisionAudioSource != null && racketCollisionAudioSource.clip != null)
        {
            racketCollisionAudioSource.PlayOneShot(racketCollisionAudioSource.clip);
        }
    }

    private void PlayOtherCollisionSound()
    {
        // Check if an audio clip is assigned for other collisions and play the sound
        if (otherCollisionAudioSource != null && otherCollisionAudioSource.clip != null)
        {
            otherCollisionAudioSource.PlayOneShot(otherCollisionAudioSource.clip);
        }
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        rb.position = Vector2.zero;
    }

    public void AddStartingForce()
    {
        // Flip a coin to determine if the ball starts left or right
        float x = Random.value < 0.5f ? -1f : 1f;

        // Flip a coin to determine if the ball goes up or down. Set the range
        // between 0.5 -> 1.0 to ensure it does not move completely horizontal.
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f)
                                      : Random.Range(0.5f, 1f);

        // Apply the initial force and set the current speed
        Vector2 direction = new Vector2(x, y).normalized;
        rb.AddForce(direction * baseSpeed, ForceMode2D.Impulse);
        currentSpeed = baseSpeed;
    }

    private void FixedUpdate()
    {
        currentSpeed += acceleration * Time.fixedDeltaTime;
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        // Clamp the velocity of the ball to the max speed
        Vector2 direction = rb.velocity.normalized;
        
        rb.velocity = direction * currentSpeed;
    }

}
