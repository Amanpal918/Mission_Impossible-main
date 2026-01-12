using UnityEngine;

public class SpikeReset : MonoBehaviour
{
    private Vector3 startPos;
     
    public void Start()
    {


        // Debug.Log("Script attached");
    }

    void Awake()
    {
        startPos = transform.position; // save initial position
         
    }

    public void ResetSpike()
    {
        Debug.Log("Spike Reset: " + gameObject.name);

        // Move spike back down
        transform.position = startPos;

        // Disable spike
        gameObject.SetActive(false);
   
    }
}