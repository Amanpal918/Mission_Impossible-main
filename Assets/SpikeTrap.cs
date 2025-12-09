using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [Header("Settings")]
    // This variable handles ONE spike per trigger
    public Transform spikeObject; 
    
    // Speed of the spike moving up
    public float riseSpeed = 5f;
    
    // How high it goes (0.6 is good for just peeking out)
    public float riseAmount = 0.2f; 

    private Vector3 activePosition;
    private bool isTriggered = false;

    void Start()
    {
        // Safety check to prevent errors if you forgot to drag the spike in
        if (spikeObject != null)
        {
            // Calculate where the spike should go (upwards)
            activePosition = spikeObject.position + Vector3.up * riseAmount;
        }
        else
        {
            Debug.LogError("Spike Object not assigned on " + gameObject.name);
        }
    }

    void Update()
    {
        // Only move if triggered and the spike actually exists
        if (isTriggered && spikeObject != null)
        {
            spikeObject.position = Vector3.MoveTowards(
                spikeObject.position, 
                activePosition, 
                riseSpeed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }
}