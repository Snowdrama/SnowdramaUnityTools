using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A 2D representation of a spring
namespace Snowdrama.Spring
{
    public class Spring2D
    {
        SpringCollection springCollection;
        Vector2 springPosition;

        int xID;
        int yID;
        public Spring2D(SpringObject config, Vector2 initialValue = new Vector2())
        {
            springCollection = new SpringCollection();
            xID = springCollection.Add(initialValue.x, config);
            yID = springCollection.Add(initialValue.y, config);
        }

        public void Update(float deltaTime)
        {
            springCollection.Update(deltaTime);
            springPosition.x = springCollection.GetValue(xID);
            springPosition.y = springCollection.GetValue(yID);
        }

        public void SetPositionTarget(Vector2 position)
        {
            springCollection.SetTarget(xID, position.x);
            springCollection.SetTarget(yID, position.y);
        }
        public void SetCurrentValue(Vector2 position)
        {
            springCollection.SetValue(xID, position.x);
            springCollection.SetValue(yID, position.y);
        }
        
        public Vector2 GetSpringPosition()
        {
            return springPosition;
        }
    }
}
