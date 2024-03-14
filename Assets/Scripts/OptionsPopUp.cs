using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsPopUp : BasePopup
{
    [SerializeField] private UIController uiControl;
    [SerializeField] private SettingsPopUp settingsControl;
    override public void Open()
    {
        base.Open();
    }
    override public void Close()
    {
        base.Close();
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