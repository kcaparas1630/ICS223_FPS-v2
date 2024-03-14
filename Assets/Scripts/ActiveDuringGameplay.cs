using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDuringGameplay : MonoBehaviour
{
    private void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_ACTIVE, OnActive);
        Messenger.AddListener(GameEvent.GAME_INACTIVE, OnInactive);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_ACTIVE, OnActive);
        Messenger.RemoveListener(GameEvent.GAME_INACTIVE, OnInactive);
    }
    virtual public void OnActive()
    {
        this.enabled = true;
    }
    virtual public void OnInactive()
    {
        this.enabled = false;
    }
}
