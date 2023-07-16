using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingMenu;

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
    }

    public void OnBackButtonClicked()
    {
        mainMenu.SetActive(true);
        settingMenu.SetActive(false);
    }

    public void OnExitButtonClicked() => Application.Quit();
}
