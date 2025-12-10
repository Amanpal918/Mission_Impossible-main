using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float jumpForce = 12f;

    [Header("Audio Clips")]
    public AudioClip jumpSound;    // Drag your 'Jump' audio here
    public AudioClip hurtSound;    // Drag your 'Hurt' audio here
    public AudioClip deathSound;   // Drag your 'Death' audio here
    
    [Header("Ground Detection")]
    public Transform feetPos;
    public float checkRadius = 0.3f;
    public LayerMask whatIsGround;

    // Public properties for Animation
    public bool IsGrounded { get; private set; }
    public bool IsRunning { get; private set; }
    public float VerticalVelocity { get; private set; }

    private Rigidbody2D rb;
    private AudioSource audioSource; // The component that plays the sound
    private float moveInput;
    private bool jumpRequest;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Try to get the AudioSource. If one doesn't exist, we add one automatically.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        
        // Jump Input
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            jumpRequest = true;
            PlaySound(jumpSound); // Play Jump Sound!
        }

        IsRunning = moveInput != 0;
        VerticalVelocity = rb.linearVelocity.y;
    }

    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);

        if (jumpRequest)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpRequest = false;
        }
    }

    // Helper function to play sound safely
    public void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    // Function to be called when Player Dies (called by GameManager)
    public void PlayDeathSound()
    {
        PlaySound(deathSound);
    }
}