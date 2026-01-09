using UnityEngine;

public class Trigscriptright : MonoBehaviour
{
    
  public Platformrisingright platform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            platform.ActivatePlatform();
        }
    }
}