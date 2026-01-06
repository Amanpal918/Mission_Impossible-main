
using UnityEngine;

public class Diamondrightmove : MonoBehaviour
{
    [Header("Setting")]
    public Transform[] diamondobj;
    public float speed = 5f;
    public float distance =0.8f;
    private Vector3 activepos;
    private Vector3[] startPositions;
    private bool istriggered = false;
    
void Awake() 
    {
        if (diamondobj != null && diamondobj.Length > 0)
        {
            // Initialize the array to match the number of diamonds
            startPositions = new Vector3[diamondobj.Length];

            // Loop through each diamond and save its current position
            for (int i = 0; i < diamondobj.Length; i++)
            {
                if (diamondobj[i] != null)
                {
                    startPositions[i] = diamondobj[i].position;
                }
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    

    // Update is called once per frame
    void Update()
    {
        if(istriggered && diamondobj !=null)
        {
            foreach(Transform diamond in diamondobj)
            {
                 diamond.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            istriggered = true;
        }
    }
    public void ResetMovement()
    {
        istriggered = false; // Stop the movement
        if (startPositions == null || diamondobj == null) 
    {
        return; 
    }
        for (int i = 0; i < diamondobj.Length; i++)
        {
            if (diamondobj[i] != null)
            {
                diamondobj[i].position = startPositions[i]; // Move back to start
            }
        }
    }
}
