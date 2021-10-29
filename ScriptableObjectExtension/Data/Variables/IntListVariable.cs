using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "IntListVariable", menuName = "GameData/IntListVariable")]
public class IntListVariable : ScriptableObject
{
    [NonSerialized] public List<int> myList;


    public void SetValue(int index, int value)
    {

    }

    
}
