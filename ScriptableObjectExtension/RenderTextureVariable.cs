using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RenderTextureVariable", menuName = "GameData/RenderTextureVariable")]
public class RenderTextureVariable : GameData
{
    [SerializeField]
    [Header("Data")]
    private RenderTexture _defaultValue;
    [SerializeField]
    private RenderTexture _value;
    public RenderTexture Value
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
