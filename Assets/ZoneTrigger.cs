using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public enum ZoneType { Death, Victory }
    public ZoneType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only trigger if the Player hits this zone
        if (collision.CompareTag("Player"))
        {
            if (type == ZoneType.Death)
            {
                GameManager.Instance.ProcessPlayerDeath();
            }
            else if (type == ZoneType.Victory)
            {
                GameManager.Instance.ProcessVictory();
            }
        }
    }
}