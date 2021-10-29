using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vector2Variable", menuName = "GameData/Vector2Variable")]
public class Vector2Variable : GameData
{
    [SerializeField]
    private Vector2 _value;
    public Vector2 Value
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
    public void ApplyChange(Vector2 amount)
    {
        Value += amount;
        this.OnDataChanged.OnEvent?.Invoke();
    }

    public void ApplyChange(Vector2Variable amount)
    {
        Value += amount.Value;
        this.OnDataChanged.OnEvent?.Invoke();
    }
}
