using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        public ObstacleManager obstacleManager;
        // public ObstacleReset obstacle;
          public LifeUi lifeUi;
        public int maxLives=3;
        private int currentLives;
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            if (player.health.IsAlive)
            {
                player.health.Die();
                model.virtualCamera.Follow = null;
                model.virtualCamera.LookAt = null;
                // player.collider.enabled = false;
                player.controlEnabled = false;

                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);
                player.animator.SetTrigger("hurt");
                player.animator.SetBool("dead", true);
                Debug.Log("Player Died");

                GameController.Instance.PlayerDied();
                
                  
                ObstacleManager.Instance.ResetAllObstaclesWithDelay(2);
                Debug.Log("Spikes Reset");
                ObstacleManager.Instance.ResetAllSpikes();
                ObstacleManager.Instance.ResetRisingPlatforms();
                ObstacleManager.Instance.ResetAllTokens();

                // respwan the player 
                Simulation.Schedule<PlayerSpawn>(2);
       
            }
        }
    }
}