using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashTimer : MonoBehaviour
{
[Header("Setting")]
public float waitTime = 3.0f;
public string nextSceneName = "MainMenu";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        StartCoroutine(LoadMenuAfterDelay());
    }
    IEnumerator LoadMenuAfterDelay()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(waitTime);

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
