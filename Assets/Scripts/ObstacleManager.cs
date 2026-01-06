using System.Collections;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
     public static ObstacleManager Instance;

    public ObstacleReset[] obstacles;
    
    
    public SpikeReset[] spikes;
    public Platformrisingleft[] risingPlatforms;

 
    public TokenReset[] tokens;
    public tokenactivation[] token1;

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

    public void  ResetAllTokens()
    {
        foreach (var token in tokens)
        {
            if (token != null)
                token.ResetToken();        
        }
        Diamondrightmove[] movingDiamonds = FindObjectsOfType<Diamondrightmove>();
    foreach (var mover in movingDiamonds)
    {
        // Debug.Log("Resetting Diamond Movement");
        mover.ResetMovement();
    }
    tokenactivation token1 = FindObjectOfType<tokenactivation>();
        {
        if (token1 != null)
            {
                
                 token1.ResetToken1();
                 Debug.Log("Resetting Token Activation");
            }
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
    

