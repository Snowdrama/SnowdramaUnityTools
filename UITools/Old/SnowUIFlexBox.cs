using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SnowUIFlexBox
{
    public float width = 0.25f;
    [Header("Margin")]
    public float margin_top = 0.0f;
    public float margin_bottom = 0.0f;
    public float margin_left = 0.0f;
    public float margin_right = 0.0f;
    [Header("Generated")]
    [EditorReadOnly]public float totalWidth = 0;
    [EditorReadOnly]public float totalHeight = 0;
    private int lastHash;


    public bool HashChanged()
    {
        var currentHash = Tuple.Create(width, margin_top, margin_bottom, margin_left, margin_right).GetHashCode();
        if (lastHash != currentHash)
        {
            lastHash = currentHash;
            return true;
        }
        return false;
    }

    public override int GetHashCode()
    {
        int hash = Tuple.Create(width, margin_top, margin_bottom, margin_left, margin_right).GetHashCode();
        lastHash = hash;
        return hash;
    }
}
