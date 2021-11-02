using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StringVariable", menuName = "GameData/StringVariable")]
public class StringVariable : GameData
{
    [SerializeField]
    [Header("Data")]
    [Tooltip("Strings have a default value for Replace style strings with [value] in them")]
    private string _defaultValue;
    [SerializeField]
    private string _value;
    public string Value
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

    //takes the _defaultValue "[VALUE]" and places it in _value
    //generally used for UI updates
    public void ReplaceFromDefault(string insertValue)
    {
        Value = _defaultValue.Replace("[value]", insertValue);
    }
    public void Concat(string amount)
    {
        Value += amount;
        this.OnDataChanged.OnEvent?.Invoke();
    }

    //TODO: Maybe add some other ways to manipulate the data
}
