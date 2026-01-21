using UnityEngine;
using UnityEngine.UI;

public class SettingPanelUi : MonoBehaviour
{
     public Slider volumeslider;
     public Toggle musictoggle;
     public Toggle sfxToggle;
     
     public GameObject settingpanel;
    void Start()
    {
        // Voilumeslider .value = PlayerPrefs .GetFloat("Volume",1f);
        // musictoggle .isOn = PlayerPrefs .GetInt("Music",1) == 1;
        // sfxToggle .isOn = PlayerPrefs .GetInt("SFX",1) ==1;
    }
public void ChangeVolume ()
    {
        // volumeslider.value = PlayerPrefs.GetInt("Volume", 1);
         Debug.Log("value"+ volumeslider.value);
        // AudioListener.volume = value;
        // PlayerPrefs .SetFloat ("volume", value);
        float sliderValue = volumeslider.value;   // 0–100
         AudioListener.volume = sliderValue;

        Debug.Log("Slider Value: " + sliderValue + " | Volume: " + AudioListener.volume);


    }
// public void ToggleMusic(bool isOn)
//     {
//         AudioManager.Instance.musicSource.mute = !isOn;
//         PlayerPrefs.SetInt("music", isOn ? 1:0);
//     }
//     public void ToggleSFX(bool isOn)
//     {
//         AudioManager.Instance.sfxSource.mute = !isOn;
//         PlayerPrefs.SetInt("SFX", isOn ? 1 : 0);
//     }
    public void CloseSettings()
    {
        settingpanel.SetActive(false);
    }
    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Progrss reset ");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

