using UnityEngine;

public class Spikeleftright : MonoBehaviour
{
    public Transform spikeObject;

    public float moveSpeed = 2f;
    public float distance = 1f;  // how far it moves left & right

    private Vector3 startPos;
    private bool isTriggered = false;

    void Start()
    {
        startPos = spikeObject.position;
    }

    void Update()
    {
        if (isTriggered)
        {
            float move = Mathf.PingPong(Time.time * moveSpeed, distance);
            spikeObject.position = startPos + Vector3.left * move;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }
}
