using System.Collections;

using UnityEngine;

public class Platformrisingright : MonoBehaviour
{
   [Header("Platform Setting")]
    public Rigidbody2D platformRb;
     public float riseSpeed = 5f;
    public float riseAmount = 0.3f;
    public float rightAmount = 0.3f; 
    public float delayBeforeright = 0.5f;
    

    private Vector2 startPos;
    private Vector2 upPos;
    private Vector2 rightPos;

    
    private bool isTriggered = false;
    private bool movingUp = false;
     
    private bool movingRight = false;

    private Vector2 previousPosition;
    private Rigidbody2D playerRb;
   void Awake()
    {
        startPos = platformRb.position;
        previousPosition = startPos;
        
        // Settings for a solid push
        platformRb.bodyType = RigidbodyType2D.Kinematic;
        platformRb.useFullKinematicContacts = true;
    }

    void Start()
    {
        platformRb.gameObject.SetActive(false);
    }

    void RecalculatePositions()
    {
        upPos = startPos + Vector2.up * riseAmount;
        rightPos = upPos + Vector2.right * rightAmount;
    }

    void FixedUpdate()
    {
        // 1. Move Platform
        if (movingUp)
        {
            Vector2 nextPos = Vector2.MoveTowards(platformRb.position, upPos, riseSpeed * Time.fixedDeltaTime);
            platformRb.MovePosition(nextPos);

            if (Vector2.Distance(platformRb.position, upPos) < 0.05f)
            {
                movingUp = false;

                StartCoroutine(RightMoveSequence());
            }
        }

        if (movingRight)
        {
            Vector2 nextPos = Vector2.MoveTowards(platformRb.position, rightPos, riseSpeed * Time.fixedDeltaTime);
            platformRb.MovePosition(nextPos);
        }

        // 2. Drag Logic (STOPS climbing because it doesn't use Parenting)
        if (playerRb != null)
        {
            Vector2 platformMovement = platformRb.position - previousPosition;
            playerRb.position += platformMovement;
        }

        previousPosition = platformRb.position;
    }

    // --- COLLISION: NO PARENTING HERE ---
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRb = null; // Stops dragging so player can fall!
        }
    }

    public void ActivatePlatform()
    {
        if (isTriggered) return;
        isTriggered = true;
        RecalculatePositions();
        movingUp = true;
        platformRb.gameObject.SetActive(true);
    }

    IEnumerator RightMoveSequence()
    {
        yield return new WaitForSeconds(delayBeforeright);
        movingRight = true;
    }

    // --- RESET FOR RESPONDING ---
    public void ResetPlatform()
    {
        StopAllCoroutines();
        isTriggered = false;
        movingUp = false;
        movingRight = false;
        playerRb = null; 
        platformRb.transform.position = startPos;
        previousPosition = startPos;
        platformRb.gameObject.SetActive(false);
    }
}