using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent_String", menuName = "GameEvents/GameEvent_String")]
public class GameEvent_Int : ScriptableObject
{
    public GameEvent<int> gameEvent;

    public void RegisterEvent(Action<int> e)
    {
        gameEvent.RegisterEvent(e);
    }

    public void UnregisterEvent(Action<int> e)
    {
        gameEvent.UnregisterEvent(e);
    }

    public void Invoke(int s)
    {
        gameEvent.OnEvent?.Invoke(s);
    }
}