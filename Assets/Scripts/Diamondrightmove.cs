
using UnityEngine;

public class Diamondrightmove : MonoBehaviour
{
    [Header("Setting")]
    public Transform[] diamondobj;
    public float speed = 5f;
    public float distance =0.8f;
    private Vector3 activepos;
    private bool istriggered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(diamondobj != null)
        {

        activepos = diamondobj[0].position + Vector3.right * distance;
        // diamondobj[0].gameObject.SetActive(true);
        }
        
    }
    

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
}
