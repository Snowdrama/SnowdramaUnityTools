using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoubleVariable", menuName = "GameData/DoubleVariable")]
public class DoubleVariable : GameData
{
    [SerializeField]
    private double _value;
    public double Value
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
    public void ApplyChange(double amount)
    {
        Value += amount;
        this.OnDataChanged.OnEvent?.Invoke();
    }

    public void ApplyChange(DoubleVariable amount)
    {
        Value += amount.Value;
        this.OnDataChanged.OnEvent?.Invoke();
    }
}
