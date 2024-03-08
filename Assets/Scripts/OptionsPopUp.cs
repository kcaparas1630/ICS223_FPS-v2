using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsPopUp : MonoBehaviour
{
    [SerializeField] private UIController uiControl;
    [SerializeField] private SettingsPopUp settingsControl;
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    public void OnSettingsButton()
    {
        Debug.Log("Settings Clicked");
        Close();
        settingsControl.Open();
    }
    public void OnExitGameButton()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
    public void OnReturnToGameButton()
    {
        Debug.Log("Return to Game");
        Close();
        uiControl.SetGameActive(true);
    }
}