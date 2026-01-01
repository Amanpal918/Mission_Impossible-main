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

    void Awake()
    {
        startPos = platformRb.position;
        upPos = startPos + Vector2.up * riseAmount;
        leftPos = upPos + Vector2.left * leftAmount;
    }

    void OnEnable()
    {
        ResetPlatform();
    }

    void FixedUpdate()
    {
        if (movingUp)
        {
            platformRb.MovePosition(
                Vector2.MoveTowards(
                    platformRb.position,
                    upPos,
                    riseSpeed * Time.fixedDeltaTime
                )
            );

            if (Vector2.Distance(platformRb.position, upPos) < 0.01f)
            {
                movingUp = false;
                StartCoroutine(LeftMoveSequence());
            }
        }

        if (movingLeft)
        {
            platformRb.MovePosition(
                Vector2.MoveTowards(
                    platformRb.position,
                    leftPos,
                    riseSpeed * Time.fixedDeltaTime
                )
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            Debug.Log("Trigger Entered");
            isTriggered = true;
            platformRb.gameObject.SetActive(true);
            movingUp = true;
        }
    }

    IEnumerator LeftMoveSequence()
    {
        yield return new WaitForSeconds(delayBeforeLeft);
        Debug.Log("Moving Left");
        movingLeft = true;
    }

    public void ResetPlatform()
    {
        Debug.Log("Resetting Platform");
        StopAllCoroutines();
        platformRb.position = startPos;
        platformRb.gameObject.SetActive(false);
        isTriggered = false;
        movingUp = false;
        movingLeft = false;
    }
}