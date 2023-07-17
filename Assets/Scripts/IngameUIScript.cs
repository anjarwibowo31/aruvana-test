using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameUIScript : MonoBehaviour
{
    [SerializeField] private GameObject muteButton;
    [SerializeField] private GameObject unmuteButton;

    [SerializeField] private GameObject visualFX;
    [SerializeField] private GameObject showVFXButton;
    [SerializeField] private GameObject hideVFXButton;

    private void Start()
    {
        visualFX.SetActive(true);
        showVFXButton.SetActive(false);
        hideVFXButton.SetActive(true);

        if (AudioManager.Instance.audioSource.mute == false)
        {
            muteButton.SetActive(true);
            unmuteButton.SetActive(false);
        }
        else
        {
            muteButton.SetActive(false);
            unmuteButton.SetActive(true);
        }
    }

    public void OnMenuButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void OnShowVFXButtonClicked()
    {
        visualFX.SetActive(true);
        showVFXButton.SetActive(false);
        hideVFXButton.SetActive(true);
    }

    public void OnHideVFXButtonClicked()
    {
        visualFX.SetActive(false);
        showVFXButton.SetActive(true);
        hideVFXButton.SetActive(false);
    }

    public void OnMuteButtonClicked()
    {
        AudioManager.Instance.audioSource.mute = true;
        muteButton.SetActive(false);
        unmuteButton.SetActive(true);
    }

    public void OnUnmuteButtonClicked()
    {
        AudioManager.Instance.audioSource.mute = false;
        muteButton.SetActive(true);
        unmuteButton.SetActive(false);
    }
}
