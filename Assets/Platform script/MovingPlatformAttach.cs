using UnityEngine;

public class MovingPlatformAttach : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
    {
        if (collision.transform.parent == transform)
            collision.transform.SetParent(null);
    }
    }
      private void OnDisable()
    {
        // SAFELY detach player when platform is disabled
        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Player"))
                    child.SetParent(null);
            }
        }
    }
     
}