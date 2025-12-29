using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelButton : MonoBehaviour
{
   public void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.Log("No next level found!");
        }
    }
}
