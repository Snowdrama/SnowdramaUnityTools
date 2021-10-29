using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameData : ScriptableObject
{
    //Might be cool to automatically invoke this.
    [Header("When Data Changed")]
    public GameEvent OnDataChanged;
#if UNITY_EDITOR
    [Multiline]
    [Tooltip("What is this variable for?")]
    public string Description = "";
#endif
}
