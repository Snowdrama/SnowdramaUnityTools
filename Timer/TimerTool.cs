using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama
{
    [System.Serializable]
    public class Timer
    {
        public event Action OnComplete;
        public event Action OnRestart; //called when the timer is set back to 0 from max
        public event Action OnStart; //called when the timer is started after stopping or on first start
        [SerializeField] private float currentTime;
        [SerializeField] private float duration;
        [SerializeField] public bool Active { get { return active; } }
        [SerializeField] private bool active;
        [SerializeField] private bool autoRestart;
        public Timer(float time, bool autoStart = false, bool autoRestart = false)
        {
            if (time <= 0)
            {
                throw new Exception("Time should be greather than 0");
            }
            duration = time;
            currentTime = 0;
            active = autoStart;
            this.autoRestart = autoRestart;
        }

        /// <summary>
        /// needs to be called in the update of a gameobject.
        /// </summary>
        /// <param name="deltaTime"></param>
        public void UpdateTime(float deltaTime)
        {
            if (active)
            {
                currentTime += deltaTime;
                if (currentTime >= duration && active)
                {
                    currentTime -= duration;
                    active = false;
                    if (autoRestart)
                    {
                        OnComplete?.Invoke();
                        RestartTimer();
                    }
                    else
                    {
                        currentTime = 0;
                        OnComplete?.Invoke();
                    }
                }
            }
        }
        /// <summary>
        /// starts or resumes the timer depending on if Stop or Pause was used
        /// </summary>
        public void Start()
        {
            if (!active)
            {
                OnStart?.Invoke();
                //the timer was paused so resume
                active = true;
            }
        }
        /// <summary>
        /// stops the timer, and resets the current time to 0
        /// </summary>
        public void Stop()
        {
            active = false;
            currentTime = 0;
        }

        /// <summary>
        /// stops the timer and allows resuming from the current time
        /// </summary>
        public void Pause()
        {
            active = false;
        }

        /// <summary>
        /// returns the current time in seconds
        /// </summary>
        /// <returns></returns>
        public float GetTime()
        {
            return currentTime;
        }

        /// <summary>
        /// returns current time as a percent of the max time
        /// </summary>
        /// <returns></returns>
        public float GetTimePercent()
        {
            return currentTime / duration;
        }

        /// <summary>
        /// start the timer over, allow passing in a new time.
        /// </summary>
        /// <param name="newTime"></param>
        public void RestartTimer(float newTime = -1)
        {
            active = true;
            OnRestart?.Invoke();
            if (newTime > 0)
            {
                duration = newTime;
            }
        }

        public void SetNewTime(float newTime)
        {
            duration = newTime;
        }
    }
}