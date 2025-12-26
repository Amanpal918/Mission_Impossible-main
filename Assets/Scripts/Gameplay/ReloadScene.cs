using UnityEngine;
using Platformer.Core;
using UnityEngine.SceneManagement;
namespace Platformer.Gameplay
{
    /// <summary>
    /// Reloads the current scene.
    /// </summary>
public class ReloadScene : Simulation.Event<ReloadScene>
{
    public override void Execute()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
}

