using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Snow.ScriptableObjectExtension
{
    [Serializable]
    public class DoubleReference
    {
        public bool UseConstant = true;
        public double ConstantValue;
        public DoubleVariable Variable;

        public DoubleReference()
        { }

        public DoubleReference(double value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public double Value
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

        public static implicit operator double(DoubleReference reference)
        {
            return reference.Value;
        }
    }
}