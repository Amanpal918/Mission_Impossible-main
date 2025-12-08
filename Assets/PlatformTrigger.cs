using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public Rigidbody2D platformrb;

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            platformrb.bodyType = RigidbodyType2D.Dynamic;
            platformrb.gravityScale = 5f;
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
