using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [Header("Settings")]
    // This variable handles ONE spike per trigger
    public Transform spikeObject; 
    
    // Speed of the spike moving up
    public float riseSpeed = 5f;
    
    // How high it goes (0.6 is good for just peeking out)
    public float riseAmount = 0.3f; 


    private Vector3 startPos;
    private Vector3 targetPos;
    private bool isTriggered;


    void Start()
    {
        spikeObject.gameObject.SetActive(false);
    }
    void Awake()
    {
        startPos = spikeObject.position;
        targetPos = startPos + Vector3.up * riseAmount;
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
                riseSpeed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {    
         spikeObject.gameObject.SetActive(true);
         isTriggered = true;
        }
    }
}