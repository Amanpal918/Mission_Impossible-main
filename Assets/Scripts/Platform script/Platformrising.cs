using UnityEngine;
using System.Collections;
using Unity.VisualScripting;


public class Platformrising : MonoBehaviour
{
    [Header("Platform Setting")]
    public Transform PlatformObject;
    public float riseSpeed = 5f;
    public float riseAmount = 0.3f;
    public float waittime = 2f;
    private Vector3 Startpos;
    private Vector3 Targetpos;


    //  private Vector3 activeposition;

     private bool isTriggered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(PlatformObject != null)
        {
            Startpos = PlatformObject.position ;// remember kaha see start kiya 
            Targetpos = PlatformObject.position + Vector3.up*riseAmount; // kaha thak jayega uski positipon store 

            PlatformObject.gameObject.SetActive(false);

            
        }
        
    }

    // Update is called once per frame

     private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")&& !isTriggered)
        {
        
            StartCoroutine(RiseFallSequence());
          
        }
    }
    IEnumerator RiseFallSequence()  
    {
       isTriggered = true;
    //    gameobect ko active karna 
        PlatformObject.gameObject.SetActive(true);

    // upar jane ke liye loop Target thak upar jane ke liye 
        while(Vector3.Distance(PlatformObject.position ,Targetpos)> 0.01f)
        {
            PlatformObject.position = Vector3.MoveTowards(PlatformObject.position,
            Targetpos,riseSpeed*Time.deltaTime);
            yield return null;
        }
    PlatformObject.position = Targetpos; 
    yield return new WaitForSeconds(waittime);  // two seconds rukne ke liye 

    //  for going down we will use another loop 
    while(Vector3.Distance(PlatformObject.position ,Startpos)> 0.01f)
        {
            PlatformObject.position = Vector3.MoveTowards(PlatformObject.position,
            Startpos,riseSpeed*Time.deltaTime);
            yield return null;
        }
    PlatformObject.position = Startpos;
     PlatformObject.gameObject.SetActive(false);
    isTriggered = false;
    }
}
