using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent_String", menuName = "GameEvents/GameEvent_String")]
public class GameEvent_Color : ScriptableObject
{
    public GameEvent<Color> gameEvent;

    public void RegisterEvent(Action<Color> e)
    {
        gameEvent.RegisterEvent(e);
    }

    public void UnregisterEvent(Action<Color> e)
    {
        gameEvent.UnregisterEvent(e);
    }

    public void Invoke(Color s)
    {
        gameEvent.OnEvent?.Invoke(s);
    }
}