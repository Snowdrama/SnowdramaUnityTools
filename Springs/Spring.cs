using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama.Spring
{
    public class Spring
    {
        private SpringConfiguration _spring;
        private SpringState _state;
        public Spring(float initialValue, SpringObject springObject)
        {
            _spring = springObject.GetConfiguration();
            _state = new SpringState(initialValue, initialValue, 0f);
        }
        public bool IsResting()
        {
            return _state.Resting;
        }

        public float GetValue()
        {
            return _state.Current;
        }

        public float GetTarget()
        {
            return _state.Target;
        }

        public float GetVelocity()
        {
            return _state.Velocity;
        }

        public void SetValue(float value)
        {
            var state = _state;
            state.Target = value;
            state.Current = value;
            state.Velocity = 0f;
            _state = state;
        }

        public void SetTarget(float value)
        {
            var state = _state;
            state.Target = value;
            _state = state;
        }

        public void SetVelocity(float value)
        {
            var state = _state;
            state.Velocity = value;
            _state = state;
        }

        public void SetNewSpring(SpringObject spring)
        {
            var config = spring.GetConfiguration();
            _spring = config;
        }

        public void Update(float deltaTime)
        {
            var state = _state;
            var config = _spring;

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
                        _state = state;
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
                        _state = state;
                        return;
                    }
                }

                deltaTime -= dt;
            }

            state.Resting = false;

            _state = state;
        }
    }
}