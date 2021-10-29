using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent_String", menuName = "GameEvents/GameEvent_String")]
public class GameEvent_String : ScriptableObject
{
    public Action<String> OnEvent;

#if UNITY_EDITOR
    [TextArea(0, 100)]
    public string notes;
#endif

    public void RegisterEvent(Action<string> e)
    {
        OnEvent += e;
    }

    public void Invoke(string s)
    {
        OnEvent?.Invoke(s);
    }
}