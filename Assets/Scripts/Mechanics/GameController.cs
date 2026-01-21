using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// This class exposes the the game model in the inspector, and ticks the
    /// simulation.
    /// </summary> 
    public class GameController : MonoBehaviour
    {
        public ObstacleManager obstacleManager;
        public static GameController Instance { get; private set; }
        public LifeUi lifeUi;
        public int maxLives=3;
        private int currentLives;

        //This model field is public and can be therefore be modified in the 
        //inspector.
        //The reference actually comes from the InstanceRegister, and is shared
        //through the simulation and events. Unity will deserialize over this
        //shared reference when the scene loads, allowing the model to be
        //conveniently configured inside the inspector.
        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

 void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
        void Start()
        {
            currentLives = maxLives;
            lifeUi.UpdateHearts(currentLives);
        }
        void OnEnable()
        {
            Instance = this;
        }

        void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        void Update()
        {
            if (Instance == this) Simulation.Tick();
        }
        //  PlatformerModel model = Simulation.GetModel<PlatformerModel>();

    public void PlayerDied()
        {
            currentLives --;
            lifeUi.UpdateHearts(currentLives);
            // Debug.Log("Player Died - GameController");
         
        }
        
    }
}