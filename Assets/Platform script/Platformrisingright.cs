using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class Platformrisingright : MonoBehaviour
{
   [Header("Platform Setting")]
    public Transform PlatformObject;
     public float riseSpeed = 5f;
    public float riseAmount = 0.3f;
    public float disAmount = 0.3f; 
    public float delayBeforeright = 0.5f;
    
    private bool moveright = false;

       private Vector3 activePosition;
    private bool isTriggered = false;
    void Start()
    {
         if(PlatformObject != null)
         {
            activePosition = PlatformObject.position + Vector3.up* riseAmount ;
            PlatformObject.gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
         if(isTriggered)
        {
            PlatformObject.position = Vector3.MoveTowards( PlatformObject.position,activePosition,riseSpeed * Time.deltaTime
            );  
        }
            if(moveright)
            {
                PlatformObject.position = Vector3.MoveTowards( PlatformObject.position,activePosition,riseSpeed * Time.deltaTime
                );  
            }
        
    }
    
      private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
                PlatformObject.gameObject.SetActive(true);
                isTriggered = true;
                StartCoroutine(rightMoveSequence());
            
            isTriggered = true;
        }
    }
     IEnumerator rightMoveSequence()
    {
        Debug.Log("entered rightmovesequence");
        while(Vector3.Distance(PlatformObject.position, activePosition) > 0.01f)
        yield return null;
        yield return new WaitForSeconds(delayBeforeright);

        // now change target to right
        activePosition = PlatformObject.position + Vector3.right * disAmount;
         Debug.Log("exited Right");
    }
}
