using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Snowdrama.Spring
{
    public class SpringCollection
    {
        public int Count => _states.Count;

        private List<SpringConfiguration> _springs;
        private List<SpringState> _states;

        public SpringCollection()
        {
            _springs = new List<SpringConfiguration>();
            _states = new List<SpringState>();
        }

        public SpringCollection(int capacity)
        {
            _springs = new List<SpringConfiguration>(capacity);
            _states = new List<SpringState>(capacity);
        }

        public int Add(float initialValue, SpringConfigurationObject spring)
        {
            var id = Count;
            var config = spring.GetConfiguration();
            var state = new SpringState(initialValue, initialValue, 0f);

            _springs.Add(config);
            _states.Add(state);

            return id;
        }
        public bool IsResting(int id)
        {
            return _states[id].Resting;
        }

        public float GetValue(int id)
        {
            return _states[id].Current;
        }

        public float GetTarget(int id)
        {
            return _states[id].Target;
        }

        public float GetVelocity(int id)
        {
            return _states[id].Velocity;
        }

        public void SetValue(int id, float value)
        {
            var state = _states[id];
            state.Current = value;
            state.Velocity = 0f;
            _states[id] = state;
        }

        public void SetTarget(int id, float value)
        {
            var state = _states[id];
            state.Target = value;
            _states[id] = state;
        }

        public void SetVelocity(int id, float value)
        {
            var state = _states[id];
            state.Velocity = value;
            _states[id] = state;
        }

        public void UpdateFloatSpring(int id, SpringConfigurationObject spring)
        {
            var config = spring.GetConfiguration();
            _springs[id] = config;
        }

        private void UpdateValue(int id, float deltaTime)
        {
            var state = _states[id];
            var config = _springs[id];

            while (deltaTime >= Mathf.Epsilon)
            {
                var dt = Mathf.Min(deltaTime, 0.016f);

                var force = -config.Tension * (state.Current - state.Target);
                var damping = -config.Friction * state.Velocity;
                var acceleration = (force + damping) / config.Mass;
                state.Velocity = state.Velocity + (acceleration * dt);
                state.Current = state.Current + (state.Velocity * dt);

                if (config.Clamp)
                {
                    if (Mathf.Abs(state.Current - state.Target) < config.Precision)
                    {
                        state.Current = state.Target;
                        state.Velocity = 0f;
                        state.Resting = true;
                        _states[id] = state;
                        return;
                    }
                }
                else
                {
                    if (Mathf.Abs(state.Velocity) < config.Precision && Mathf.Abs(state.Current - state.Target) < config.Precision)
                    {
                        state.Current = state.Target;
                        state.Velocity = 0f;
                        state.Resting = true;
                        _states[id] = state;
                        return;
                    }
                }

                deltaTime -= dt;
            }

            state.Resting = false;

            _states[id] = state;
        }
        public void Update(float deltaTime)
        {
            for (var i = 0; i < Count; i++)
            {
                UpdateValue(i, deltaTime);
            }
        }
    }
}
