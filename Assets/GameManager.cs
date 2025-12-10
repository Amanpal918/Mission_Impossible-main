
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     public static  GameManager Instance ;
      [Header ("reference ")]
        public Transform player;
        public Transform spawnPoint; 

        [Header ("set")]
        public float respawnDelay =0.1f;

    private void Awake()
    {
    if (Instance == null) Instance = this;
      else Destroy(gameObject);
     
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        RespawnPlayerImmediate();
    }
    public void ProcessPlayerDeath()
    {
        Debug.Log("Player Died. Respawning...");
        
        var playerCtrl = player.GetComponent<PlayerController>();
        if (playerCtrl != null) 
        {
            playerCtrl.PlayDeathSound(); // <--- Add this line!
            playerCtrl.enabled = false;
        }

        StartCoroutine(RespawnRoutine());
    }
     public void ProcessVictory()
    {
        Debug.Log("level Completed ");

    }
     private System.Collections.IEnumerator RespawnRoutine()
    {
        yield return new WaitForSeconds(respawnDelay);
        RespawnPlayerImmediate();
    }
    private void RespawnPlayerImmediate()
    {
     player.position = spawnPoint.position;   
      Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

      if(rb !=null) rb.linearVelocity = Vector2.zero;

        var playerCtrl = player.GetComponent<PlayerController>();
        if (playerCtrl != null) playerCtrl.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
