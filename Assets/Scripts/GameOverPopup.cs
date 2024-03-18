using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPopup : BasePopup
{
    override public void Open()
    {
        base.Open();
    }
    override public void Close()
    {
        base.Close();
    }

    public void OnExitGameButton()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
    public void OnStartAgainButton()
    {
        Close();
        Messenger.Broadcast(GameEvent.RESTART_GAME);
    }

}
