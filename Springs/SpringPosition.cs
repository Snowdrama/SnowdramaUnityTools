using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Snowdrama.Spring;
namespace Snowdrama.Spring
{
    public class SpringPosition : MonoBehaviour
    {
        public SpringObject springObject;
        public GameObject targetPosition;
        public Vector3 offset;
        Spring springX;
        Spring springY;
        Spring springZ;
        // Start is called before the first frame update
        void Start()
        {
            springX = new Spring(targetPosition.transform.position.x, springObject);
            springY = new Spring(targetPosition.transform.position.y, springObject);
            springZ = new Spring(targetPosition.transform.position.x, springObject);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
    #if UNITY_EDITOR
            if(springX == null)
            {
                springX = new Spring(0, springObject);
                springY = new Spring(0, springObject);
                springZ = new Spring(0, springObject);
            }
            springX.SetNewSpring(springObject);
            springY.SetNewSpring(springObject);
            springZ.SetNewSpring(springObject);
    #endif
            springX.Update(Time.fixedUnscaledDeltaTime);
            springY.Update(Time.fixedUnscaledDeltaTime);
            springZ.Update(Time.fixedUnscaledDeltaTime);


            springX.SetTarget(targetPosition.transform.position.x);
            springY.SetTarget(targetPosition.transform.position.y);
            springZ.SetTarget(targetPosition.transform.position.z);

            this.transform.position = offset + new Vector3(springX.GetValue(), springY.GetValue(), springZ.GetValue());
        }
    }
}