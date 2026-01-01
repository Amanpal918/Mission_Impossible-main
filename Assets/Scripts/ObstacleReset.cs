using UnityEngine;

public class ObstacleReset : MonoBehaviour
{
   private Vector3 startpos;
   private bool Startactive;
   private Rigidbody2D rb;
    private RigidbodyType2D startBodyType;
    private float startGravity;

    void Awake()
    {
        startpos = transform.position;
        Startactive = gameObject. activeSelf;
        rb = GetComponent<Rigidbody2D>();
          if (rb != null)
        {
            startBodyType = rb.bodyType;
            startGravity = rb.gravityScale;
        }
        Debug.Log($"[ObstacleReset] Saved start data for: {gameObject.name}");
    } 
     public void ResetWithDelay()
    {
        Invoke(nameof(resetObstacle),2f);
    }
     public void resetObstacle()
    {
        Debug.Log($"[ObstacleReset] ResetObstacle called on: {gameObject.name}");
        Debug.Log("obstacle reset step1");

        transform.position = startpos;
        Debug.Log("obstacle reset step2");
        gameObject.SetActive(Startactive);
            Debug.Log("obstacle reset step3");
         if (rb != null)
        {
            
        rb.bodyType = startBodyType;
        rb.gravityScale = startGravity;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
         
        // Debug.Log(" obstacle");
        
        }
    }
   
}
