using UnityEngine;

public class Trigscript : MonoBehaviour
{
  public Platformrisingleft platform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            platform.ActivatePlatform();
        }
    }
}