using NUnit.Framework;
using UnityEngine;

public class spikemoveleft : MonoBehaviour
{
      [Header("Settings")]
    // This variable handles ONE spike per trigger
    public Transform spikeObject; 
    
    // Speed of the spike moving to left 
    public float moveSpeed = 5f;
    
    // How hright or left  it goes (0.6 is good for just right out)
    public float distanceAmount = 0.3f; 

    private Vector3 startPos;          // starting position
    private Vector3 targetPos;         // where spike will go
    private bool isTriggered ;

    void Awake()
    {
        startPos = spikeObject.position;
        targetPos = startPos+Vector3.left*distanceAmount; 
    }

    void OnEnable()
    {
        isTriggered = false;
        spikeObject.position = startPos;
        spikeObject.gameObject.SetActive(true);
    }
    void Update()
    {
        // Only move if triggered and the spike actually exists
        if (isTriggered && spikeObject != null)
        {
            spikeObject.position = Vector3.MoveTowards(
                spikeObject.position, 
                targetPos, 
                moveSpeed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            isTriggered = true;
            spikeObject.gameObject.SetActive(true);
        }
    }
}
