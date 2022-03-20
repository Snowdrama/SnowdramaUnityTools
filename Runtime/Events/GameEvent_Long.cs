using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent_String", menuName = "GameEvents/GameEvent_String")]
public class GameEvent_Long : ScriptableObject
{
    public GameEvent<long> gameEvent;

    public void RegisterEvent(Action<long> e)
    {
        gameEvent.RegisterEvent(e);
    }

    public void UnregisterEvent(Action<long> e)
    {
        gameEvent.UnregisterEvent(e);
    }

    public void Invoke(long s)
    {
        gameEvent.OnEvent?.Invoke(s);
    }
}