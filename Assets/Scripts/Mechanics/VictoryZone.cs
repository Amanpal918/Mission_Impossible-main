using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using UnityEngine.SceneManagement;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    public class VictoryZone : MonoBehaviour
    {
          [Header("Ui References")]
     public GameObject UICanvas;
     public GameObject victorypanel;

    
    void ShowVictory()
    {
        
        // Time.timeScale = 0f;
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f; // Unfreeze the game
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }
        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("entered the victory zone ");
             if(collider.CompareTag("Player"))
           {
            Debug.Log("step 1");
            ShowVictory();
            Debug.Log("step 2");
            UICanvas.SetActive(true);
            
            victorypanel.SetActive(true);
            Debug.Log("step 3");
           }

            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                Debug.Log("step 4");
                var ev = Schedule<PlayerEnteredVictoryZone>();
                ev.victoryZone = this;
            }
        }
    }
}