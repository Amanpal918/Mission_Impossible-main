using System;
using Platformer.Gameplay;
// using Platformer.Mechanics;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {

            GameController.Instance.Reswapn();       
            Debug.Log("Player Hit Spike");
    }
        }
    }


