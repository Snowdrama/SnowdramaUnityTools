using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama
{
    public class Iterator
    {
        public event Action OnStop;
        public event Action OnIterate; //called each timer iteration
        public event Action OnStart; //called when the timer is started
        [SerializeField] private float currentTime;
        [SerializeField] private float iterateTime;
        [SerializeField] private float totalTime;
        [SerializeField] private float duration; //how long to iterate for before stopping, less than 0 = forever
        [SerializeField] private bool active;
        [SerializeField] private bool starting;
        [SerializeField] private bool autoStart;
        public Iterator(float iterateTime, float duration = -1, bool autoStart = true)
        {
            currentTime = 0;
            this.iterateTime = iterateTime;
            this.duration = duration;
            this.autoStart = autoStart;
            if (this.autoStart)
            {
                active = true;
            }
        }

        public void SetNewItterateTime(float iterateTime)
        {
            this.iterateTime = iterateTime;
        }

        public void UpdateTime(float deltaTime)
        {
            if (active)
            {
                currentTime += deltaTime;
                if (currentTime > iterateTime)
                {
                    OnIterate?.Invoke();
                    currentTime = 0;
                }
                if (duration > 0)
                {
                    totalTime += deltaTime;
                    if (totalTime > duration)
                    {
                        active = false;
                        OnStop?.Invoke();
                        totalTime = 0;
                    }
                }
            }
        }
        //starts or resumes the timer depending on if Stop or Pause was used
        public void Start()
        {
            if (!active)
            {
                OnStart?.Invoke();
            }
            active = true;
        }
        //stops the timer, and resets the current time to 0
        public void Stop()
        {
            if (active)
            {
                OnStop?.Invoke();
            }
            active = false;
            currentTime = 0;
        }

        //stops the timer and allows resuming from the current time
        public void Pause()
        {
            active = false;
        }
        //returns the current time in seconds
        public float GetTime()
        {
            return currentTime;
        }

        //returns current time as a percent of the max time
        public float GetTimePercent()
        {
            return currentTime / duration;
        }
    }
}