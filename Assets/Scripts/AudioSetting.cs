using UnityEngine;
using UnityEngine.UI;
public class AudioSetting : MonoBehaviour
{
    public Slider volumeslider;
    void Start()
    {
        

        // volumeslider.value = PlayerPrefs.GetFloat("Volume", 1);
        AudioListener .volume = volumeslider.value;
        Debug.Log("audio played");

    }

    // Update is called once per frame
    public void ChangeVolume(float  value)
    {

        Debug.Log("Voulume changed");
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("Volume", value);
    }
}
