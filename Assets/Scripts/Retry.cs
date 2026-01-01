using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
     public void RetryLevel()
    {
          Time.timeScale = 1f;
        // Reload current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
