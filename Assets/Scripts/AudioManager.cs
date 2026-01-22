using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static  AudioManager Instance;
    // public AudioSource musicSource;
    // public AudioSource sfxSource;
    public AudioSource audioSource;
    public AudioClip clip;
    public AudioClip[] clips;

    public Slider volumeslider;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
          audioSource.clip = clip;
        audioSource.Play();

    }
    public void ToggleMusic(bool isOn)
    {
        audioSource.mute = !isOn;
    }
    // public void ToggleSFx(bool isOn)
    // {
    //      sfxSource.mute = !isOn;
    // }
   
   
}
