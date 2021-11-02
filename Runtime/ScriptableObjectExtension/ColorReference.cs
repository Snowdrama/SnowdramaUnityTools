using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snow.ScriptableObjectExtension
{
    [Serializable]
    public class ColorReference
    {
        public bool UseConstant = true;
        public Color ConstantValue;
        public ColorVariable Variable;

        public ColorReference()
        { }

        public ColorReference(Color value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public Color Value
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

        public static implicit operator Color(ColorReference reference)
        {
            return reference.Value;
        }
    }
}