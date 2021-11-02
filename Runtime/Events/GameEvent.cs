using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvents/GameEvent")]
public class GameEvent : ScriptableObject
{
    public Action OnEvent;

#if UNITY_EDITOR
    [TextArea(0, 100)]
    public string notes;
#endif

    public void RegisterEvent(Action e)
    {
        OnEvent += e;
    }

    public void UnregisterEvent(Action e)
    {
        OnEvent -= e;
    }

    public void Invoke()
    {
        OnEvent?.Invoke();
    }
}
