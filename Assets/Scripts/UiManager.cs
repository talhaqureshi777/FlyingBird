using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanal;
    [SerializeField] GameObject settingPanal;

    private void Start()
    {
        mainMenuPanal.SetActive(true);
        settingPanal.SetActive(false);
    }
    public void PlayBtnClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingBtnClicked()
    {
        mainMenuPanal.SetActive(false);
        settingPanal.SetActive(true);
    }

    public void QuitBtnClicked()
    {
        Application.Quit();
    }

    public void BackBtnClicked()
    {
        mainMenuPanal.SetActive(true);
        settingPanal.SetActive(false);
    }
}
