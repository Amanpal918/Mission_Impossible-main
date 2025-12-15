using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        // This loads the next scene in the Build Settings list
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Call this function to close the game
    public void QuitGame()
    {
        Debug.Log("Quit Game!"); // Just to show it works in the Editor
        Application.Quit();
    }
}
