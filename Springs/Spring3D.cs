using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//A 2D representation of a spring
namespace Snowdrama.Spring
{
    public class Spring3D
    {
        SpringCollection springCollection;
        Vector3 springPosition;

        int xID;
        int yID;
        int zID;
        public Spring3D(SpringConfigurationObject config, Vector3 initialValue = new Vector3())
        {
            springCollection = new SpringCollection();
            xID = springCollection.Add(initialValue.x, config);
            yID = springCollection.Add(initialValue.y, config);
            zID = springCollection.Add(initialValue.z, config);
        }

        public void Update(float deltaTime)
        {
            springCollection.Update(deltaTime);
            springPosition.x = springCollection.GetValue(xID);
            springPosition.y = springCollection.GetValue(yID);
            springPosition.z = springCollection.GetValue(zID);
        }

        public void SetPositionTarget(Vector3 position)
        {
            springCollection.SetTarget(xID, position.x);
            springCollection.SetTarget(yID, position.y);
            springCollection.SetTarget(zID, position.z);
        }
        public void SetCurrentValue(Vector3 position)
        {
            springCollection.SetValue(xID, position.x);
            springCollection.SetValue(yID, position.y);
            springCollection.SetValue(zID, position.z);
        }

        public Vector3 GetSpringPosition()
        {
            return springPosition;
        }
    }
}
