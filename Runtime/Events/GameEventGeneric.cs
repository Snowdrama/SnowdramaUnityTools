using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvents/GameEvent")]
public class GameEvent<T>
{
    public Action<T> OnEvent;

    public void RegisterEvent(Action<T> e)
    {
        OnEvent += e;
    }

    public void UnregisterEvent(Action<T> e)
    {
        OnEvent -= e;
    }

    public void Invoke(T data)
    {
        OnEvent?.Invoke(data);
    }
}
