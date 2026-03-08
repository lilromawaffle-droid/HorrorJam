using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AUDIO SOURCE")]
    [SerializeField] AudioSource backgroundSource;
    [SerializeField] AudioSource sfxSource;


    [Header("SFX")]
    //background
    [SerializeField] AudioClip ambient1;
    [SerializeField] AudioClip ambient2;

    //SFX
    [SerializeField] AudioClip cameraCapture;
    [SerializeField] AudioClip prideDie;

    void Start()
    {
        PlayerStateMachine.instance.onCameraCapture += OnCameraCapture;   
    }
    void OnDestroy()
    {
        PlayerStateMachine.instance.onCameraCapture -= OnCameraCapture;   
        
    }

    void Update()
    {
        
    }

    void OnCameraCapture()
    {
        sfxSource.clip = cameraCapture;
        sfxSource.Play();
    }
}
