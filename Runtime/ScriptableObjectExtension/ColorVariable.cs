
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "ColorVariable", menuName = "GameData/ColorVariable")]
    public class ColorVariable : GameData
    {
        [SerializeField]
        private Color _value;
        public Color Value
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
        public void ApplyChange(Color amount)
        {
            Value += amount;
            this.OnDataChanged.OnEvent?.Invoke();
        }

        public void ApplyChange(ColorVariable amount)
        {
            Value += amount.Value;
            this.OnDataChanged.OnEvent?.Invoke();
        }
    }