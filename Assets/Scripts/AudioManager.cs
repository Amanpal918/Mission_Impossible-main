using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static  AudioManager Instance;
    // public AudioSource musicSource;
    // public AudioSource sfxSource;
    public AudioSource audioSource;
    public AudioClip clip;
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
   
   
}
