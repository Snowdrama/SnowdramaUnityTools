using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent_String", menuName = "GameEvents/GameEvent_String")]
public class GameEvent_Double : ScriptableObject
{
    public GameEvent<double> gameEvent;

    public void RegisterEvent(Action<double> e)
    {
        gameEvent.RegisterEvent(e);
    }

    public void UnregisterEvent(Action<double> e)
    {
        gameEvent.UnregisterEvent(e);
    }

    public void Invoke(double s)
    {
        gameEvent.OnEvent?.Invoke(s);
    }
}