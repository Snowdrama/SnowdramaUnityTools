using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntVariable", menuName = "GameData/IntVariable")]
public class IntVariable : GameData
{
    [SerializeField]
    private int _value;
    public int Value
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
    public void ApplyChange(int amount)
    {
        Value += amount;
        this.OnDataChanged.OnEvent?.Invoke();
    }

    public void ApplyChange(IntVariable amount)
    {
        Value += amount.Value;
        this.OnDataChanged.OnEvent?.Invoke();
    }
}
