using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelButton : MonoBehaviour
{
   public void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 4);
         
            if (nextIndex > unlockedLevel)
        {
             PlayerPrefs.SetInt("UnlockedLevel", nextIndex);
            PlayerPrefs.Save();
        }

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
