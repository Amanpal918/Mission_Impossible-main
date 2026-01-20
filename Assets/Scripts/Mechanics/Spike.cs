using UnityEngine;
using Platformer.Core;  
    
namespace Platformer.Gameplay
{
public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Simulation.Schedule<PlayerDeath>();
            Debug.Log("Player Hit Spike");
    }
        }
    }

}

