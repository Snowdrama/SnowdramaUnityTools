using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "GameData/FloatVariable")]
public class FloatVariable : GameData
{
    [SerializeField]
    private float _value;
    public float Value
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
    public void ApplyChange(float amount)
    {
        Value += amount;
        this.OnDataChanged.OnEvent?.Invoke();
    }

    public void ApplyChange(FloatVariable amount)
    {
        Value += amount.Value;
        this.OnDataChanged.OnEvent?.Invoke();
    }
}