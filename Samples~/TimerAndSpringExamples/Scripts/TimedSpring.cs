using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snowdrama.Spring;

namespace Snowdrama.Examples
{
    /// <summary>
    /// This class takes a game object and uses a spring and a timer to move an object between 2 points.
    /// </summary>
    public class TimedSpring : MonoBehaviour
    {
        public SpringConfigurationObject springConfigurationObject;
        public Spring3D spring3D;

        public Transform firstPoint;
        public Transform secondPoint;

        public bool toggleState;

        public Timer toggleTimer;
        // Start is called before the first frame update
        void Start()
        {
            spring3D = new Spring3D(springConfigurationObject, new Vector3());
            
            // the bools are for auto start and auto restart so it will continue after stopping
            toggleTimer = new Timer(2.0f, true, true);

            //This callback will run after the time defined above, 2 seconds.
            toggleTimer.OnComplete += () => 
            {
                toggleState = !toggleState;    
            };
        }

        // Update is called once per frame
        void Update()
        {
            toggleTimer.UpdateTime(Time.deltaTime);//timers aren't components so they need to be manually updated
            spring3D.Update(Time.deltaTime);//Springs aren't components, so they need to be manually updated
            if (toggleState)
            {
                spring3D.SetPositionTarget(firstPoint.transform.position);
            }
            else
            {
                spring3D.SetPositionTarget(secondPoint.transform.position);
            }
            this.transform.position = spring3D.GetSpringPosition();
        }
    }
}