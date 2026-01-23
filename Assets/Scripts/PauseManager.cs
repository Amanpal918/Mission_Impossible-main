using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
     public GameObject PausePanel;

     private bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PauseGame()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale= 1f;
        PausePanel.SetActive(false);
        isPaused = false;
    }
    public void ReplayGame()
    {
        Time.timeScale = 1f;
        // CancelInvoke();
        StopAllCoroutines();
        Simulation.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // public void OpenSettings()
    // {
    //     // Implement settings menu opening logic here
    //     Debug.Log("Settings menu opened.");
    // }
    public void GotoMainMenu()
    {
    Time.timeScale = 1f;
    SceneManager.LoadScene("MainMenu");
    }
}
