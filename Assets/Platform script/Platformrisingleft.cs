using System.Collections;
using UnityEngine;

public class Platformrisingleft : MonoBehaviour
{
    [Header("Platform Setting")]
    public Rigidbody2D platformRb;
    public float riseSpeed = 5f;
    public float riseAmount = 0.3f;
    public float leftAmount = 0.3f;
    public float delayBeforeLeft = 1f;

    private Vector2 startPos;
    private Vector2 upPos;
    private Vector2 leftPos;

    private bool isTriggered = false;
    private bool movingUp = false;
    private bool movingLeft = false;

    // --- ADDED FOR PLAYER DRAGGING ---
    private Vector2 previousPosition;
    private Transform playerTransform;

    void Start()
    {
        startPos = platformRb.position;
        platformRb.gameObject.SetActive(false);
    }

    void Awake()
    {
        startPos = platformRb.position;
        previousPosition = startPos;
    }

    void RecalculatePositions()
    {
        upPos = startPos + Vector2.up * riseAmount;
        leftPos = upPos + Vector2.left * leftAmount;
    }

    void FixedUpdate()
    {
    

        if (movingUp)
        {
            Vector2 nextPos = Vector2.MoveTowards(platformRb.position, upPos, riseSpeed * Time.fixedDeltaTime);
            platformRb.MovePosition(nextPos);

            if (Vector2.Distance(platformRb.position, upPos) < 0.05f)
            {
                movingUp = false;
                StartCoroutine(LeftMoveSequence());
            }
        }

        if (movingLeft)
        {
            Vector2 nextPos = Vector2.MoveTowards(platformRb.position, leftPos, riseSpeed * Time.fixedDeltaTime);
            platformRb.MovePosition(nextPos);
        }
    }

        // --- ADDED LOGIC TO DRAG PLAYER ---
    //     if (playerTransform != null)
    //     {
    //         // Calculate how much the platform moved this frame
    //         Vector2 platformMovement = currentPos - previousPosition;
    //         // Apply that same movement to the player
    //         playerTransform.position += (Vector3)platformMovement;
    //     }

    //     previousPosition = platformRb.position;
    // }

    // // --- DETECT PLAYER ON TOP ---
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         playerTransform = collision.transform;
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         playerTransform = null;
    //     }
    // }
    // --- THIS REPLACES THE DRAG LOGIC ---
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Makes the player move WITH the platform automatically
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Returns the player to world space when they jump off
            collision.transform.SetParent(null);
        }
    }

    public void ActivatePlatform()
    {
        if (isTriggered) return;
        isTriggered = true;
        RecalculatePositions();
        movingUp = true;
        movingLeft = false;
        platformRb.gameObject.SetActive(true);
    }

    IEnumerator LeftMoveSequence()
    {
        yield return new WaitForSeconds(delayBeforeLeft);
        movingLeft = true;
    }

    public void ResetPlatform()
    {
        StopAllCoroutines();
        platformRb.transform.position = startPos;
        previousPosition = startPos; // Reset this too
        // playerTransform = null;
        isTriggered = false;
        movingUp = false;
        movingLeft = false;
        platformRb.gameObject.SetActive(false);
    }
}