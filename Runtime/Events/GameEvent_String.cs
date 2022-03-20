using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent_String", menuName = "GameEvents/GameEvent_String")]
public class GameEvent_String : ScriptableObject
{
    public GameEvent<string> gameEvent;

    public void RegisterEvent(Action<string> e)
    {
        gameEvent.RegisterEvent(e);
    }

    public void UnregisterEvent(Action<string> e)
    {
        gameEvent.UnregisterEvent(e);
    }

    public void Invoke(string s)
    {
        gameEvent.OnEvent?.Invoke(s);
    }
}