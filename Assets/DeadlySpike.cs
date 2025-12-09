using UnityEngine;
using Platformer.Core;      // Needed to access the Simulation system
using Platformer.Gameplay;  // Needed to access the PlayerDeath event

public class DeadlySpike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. Check if the object is the Player
        if (collision.CompareTag("Player"))
        {
            // 2. Instead of destroying the object, we schedule the PlayerDeath event.
            // This triggers the code you shared: plays "hurt" anim, audio, and respawns.
            Simulation.Schedule<PlayerDeath>();
        }
    }
}