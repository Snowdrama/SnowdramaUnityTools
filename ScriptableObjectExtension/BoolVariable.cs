using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoolVariable", menuName = "GameData/BoolVariable")]
public class BoolVariable : GameData
{
    [SerializeField]
    private bool _value;
    public bool Value
    {
        get
        {
                return _value;
        }
        set
        {
            _value = value;
            this.OnDataChanged?.OnEvent?.Invoke();
        }
    }
}
