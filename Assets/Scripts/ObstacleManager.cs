using System.Collections;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
     public static ObstacleManager Instance;

    public ObstacleReset[] obstacles;
    [Header("Spikes")]
    public SpikeReset[] spikes;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        
            Destroy(gameObject);

        obstacles = FindObjectsByType<ObstacleReset>(FindObjectsSortMode.None);
        //   Debug.Log("[ObstacleManager] Obstacles found: " + obstacles.Length);
        
    }
     public void ResetAllObstaclesWithDelay(float delay)
    {
        StartCoroutine(ResetAfterDelay(delay));
        // Debug.Log("[ObstacleManager] ResetAllObstacles called");
        // Debug.Log("[ObstacleManager] Obstacles found: " + obstacles.Length);
    }
    private IEnumerator ResetAfterDelay(float delay)
    {
            yield return new WaitForSeconds(delay);
        foreach (ObstacleReset obstacle in obstacles)
        {
            obstacle.resetObstacle();
        }
        
    }
    public void ResetAllSpikes()
    {
       

        foreach (SpikeReset spike in spikes)
        {
            spike.ResetSpike();
        }
    }
}
    

