using UnityEngine;
using Platformer.Gameplay;
using Platformer.Mechanics;
using Platformer.Core;

public class Tokendestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<PlayerController>();
            if(player != null)
            {
                Simulation.Schedule<PlayerDeath>();
                Debug.Log("player ne touch kiya ");
            }
        }
    }


}
