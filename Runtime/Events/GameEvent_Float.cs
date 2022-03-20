using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent_String", menuName = "GameEvents/GameEvent_String")]
public class GameEvent_Float : ScriptableObject
{
    public GameEvent<float> gameEvent;

    public void RegisterEvent(Action<float> e)
    {
        gameEvent.RegisterEvent(e);
    }

    public void UnregisterEvent(Action<float> e)
    {
        gameEvent.UnregisterEvent(e);
    }

    public void Invoke(float s)
    {
        gameEvent.OnEvent?.Invoke(s);
    }
}