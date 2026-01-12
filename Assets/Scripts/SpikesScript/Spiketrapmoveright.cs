using UnityEngine;

public class Spiketrapmove : MonoBehaviour
{
    [Header("Settings")]
    // This variable handles ONE spike per trigger
    public Transform spikeObject; 
    
    // Speed of the spike moving right
    public float moveSpeed = 5f;
    
    // How right it goes (0.6 is good for just right out)
    public float distanceAmount = 0.3f; 

    private Vector3 startpos;
    private Vector3 targetpos;

    private bool isTriggered ;

void Awake()
    {
        startpos = spikeObject.position;
        targetpos = startpos + Vector3.right*distanceAmount; 
    }

    void OnEnable()
    {
        isTriggered = false;
        spikeObject.position = startpos;
        spikeObject.gameObject.SetActive(true);
        
    }
    void Update()
    {
        // Only move if triggered and the spike actually exists
        if (isTriggered && spikeObject != null)
        {
            spikeObject.position = Vector3.MoveTowards(
                spikeObject.position, 
                targetpos, 
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
