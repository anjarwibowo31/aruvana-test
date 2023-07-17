using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public void OnPlay()
    {
        AudioManager.Instance.audioSource.Play();
    }

    public void OnPause()
    {
        AudioManager.Instance.audioSource.Pause();
    }

    public void OnStop()
    {
        AudioManager.Instance.audioSource.Stop();
    }
}