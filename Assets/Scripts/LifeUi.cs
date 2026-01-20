using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeUi : MonoBehaviour
{
    [SerializeField]
    public Image[] hearts;
    [SerializeField] private GameObject gameOverPanel;
     
     public void UpdateHearts(int lives)
    {  
        //  Debug.Log("step1");
        for(int i =0; i<hearts.Length;i++)
        {
            //  Debug.Log("step2");
             if(i<lives)
            hearts[i].enabled = true;
          else
          {
            hearts[i].enabled = false;
          }

        }
        if(lives<=0)
        {
            showGameOver();
        }
        
    }
void showGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
     public void GoToLevelSelect()
    {
        Time.timeScale = 1f; // IMPORTANT
        SceneManager.LoadScene("LevelSelect");
    }

}
