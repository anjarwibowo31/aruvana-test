using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingMenu;

    [SerializeField] private GameObject muteButton;
    [SerializeField] private GameObject unmuteButton;

    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        mainMenu.SetActive(true);
        settingMenu.SetActive(false);
    }

    public void OnStartButtonClicked() => SceneManager.LoadScene(1);

    public void OnSettingButtonClicked()
    {
        mainMenu.SetActive(false);
        settingMenu.SetActive(true);

        volumeSlider.value = AudioManager.Instance.audioSource.volume;

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

    public void OnBackButtonClicked()
    {
        mainMenu.SetActive(true);
        settingMenu.SetActive(false);
    }

    public void OnMuteButtonClicked()
    {
        AudioManager.Instance.audioSource.mute = true;
        muteButton.SetActive(false);
        unmuteButton.SetActive(true);
    }

    public void OnSliderValueChanged()
    {
        AudioManager.Instance.audioSource.volume = volumeSlider.value;
    }

    public void OnUnmuteButtonClicked()
    {
        AudioManager.Instance.audioSource.mute = false;
        muteButton.SetActive(true);
        unmuteButton.SetActive(false);
    }

    public void OnExitButtonClicked() => Application.Quit();
}
