using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Vector2Reference
{
    public bool UseConstant = true;
    public Vector2 ConstantValue;
    public Vector2Variable Variable;

    public Vector2Reference()
    { }

    public Vector2Reference(Vector2 value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public Vector2 Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
        set
        {
            if (UseConstant)
            {
                ConstantValue = value;
            }
            else
            {
                Variable.Value = value;
            }
        }
    }

    public static implicit operator Vector2(Vector2Reference reference)
    {
        return reference.Value;
    }
}
