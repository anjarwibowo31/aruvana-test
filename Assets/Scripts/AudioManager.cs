using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Ini singleton
    public static AudioManager Instance {  get; private set; }

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Butuh script di ARScene untuk men-call ini
    public void OnPlay()
    {
        audioSource.Play();
    }

    // Butuh script di ARScene untuk men-call ini
    public void OnPause()
    {
        audioSource.Pause();
    }

    // Butuh script di ARScene untuk men-call ini
    public void OnStop()
    {
        audioSource.Stop();
    }
}
