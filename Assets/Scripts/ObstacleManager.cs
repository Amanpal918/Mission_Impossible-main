using System.Collections;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
     public static ObstacleManager Instance;

    public ObstacleReset[] obstacles;
    [Header("Spikes")]
    
    public SpikeReset[] spikes;
    public Platformrisingleft[] risingPlatforms;

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
    //    Debug.Log("step 1");

        foreach (SpikeReset spike in spikes)
        {
            spike.ResetSpike();
        }
    }
     public void ResetRisingPlatforms()
    {
        foreach( var platform in risingPlatforms)
        {
            platform.ResetPlatform();
        }
    }
}
    

