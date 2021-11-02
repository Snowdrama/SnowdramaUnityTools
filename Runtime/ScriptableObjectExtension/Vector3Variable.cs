using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vector3Variable", menuName = "GameData/Vector3Variable")]
public class Vector3Variable : GameData
{
    [SerializeField]
    private Vector3 _value;
    public Vector3 Value
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
    public void ApplyChange(Vector3 amount)
    {
        Value += amount;
        this.OnDataChanged.OnEvent?.Invoke();
    }

    public void ApplyChange(Vector3Variable amount)
    {
        Value += amount.Value;
        this.OnDataChanged.OnEvent?.Invoke();
    }
}
