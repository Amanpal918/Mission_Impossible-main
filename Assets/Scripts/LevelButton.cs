
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int levelNumber; 
    //  public GameObject Locktext;
     private Button button;
     private Image image;
    void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
         int UnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 3);    
         if(levelNumber <=UnlockedLevel)
        {
            button.interactable = true;
            image.color = new Color(1f,1f,1f,1f);
            // Locktext.SetActive(false);
        }
        else
        {
            button.interactable = false;
            image.color = new Color(130f / 255f, 130f / 255f, 130f / 255f, 1f); // Set to grayed out color
            // Locktext.SetActive(true);
        }

    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelNumber);
    }
}
