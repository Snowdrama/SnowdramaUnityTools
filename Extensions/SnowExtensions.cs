using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SnowUtils
{
    public static GameObject Instantiate(this GameObject go, Vector3 position, Quaternion rotation = new Quaternion(), GameObject parent = null)
    {
        if(go != null)
        {
            var newGo = UnityEngine.Object.Instantiate(go, position, rotation);
            if(parent != null)
            {
                newGo.transform.parent = parent.transform;
            }
            return newGo;
        }
        else
        {
            //Debug.LogWarning("Tried to instantiate a null GameObject");
        }
        return go;
    }

    public static float Clamp(this float f, float min, float max)
    {
        return Mathf.Clamp(f, min, max);
    }

    public static bool LayerContains(this LayerMask layermask, int layer)
    {
        return layermask == (layermask | (1 << layer));
    }

    public static Color GetColorFromRainbow(float t, float of = 1, Gradient gradient = null)
    {
        Gradient g;
        if (gradient == null)
        {
            g = gradient;
        }
        else
        {
            g = new Gradient();
            GradientColorKey[] colorKeys = new GradientColorKey[8];
            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
            alphaKeys[0].alpha = 1;
            alphaKeys[1].alpha = 1;
            alphaKeys[0].time = 0;
            alphaKeys[0].time = 1;

            colorKeys[0].color = Color.red;
            colorKeys[1].color = Color.yellow;
            colorKeys[2].color = Color.green;
            colorKeys[3].color = Color.cyan;
            colorKeys[4].color = Color.blue;
            colorKeys[5].color = Color.magenta;
            colorKeys[6].color = Color.white;
            colorKeys[7].color = Color.black;

            colorKeys[0].time = 0.0f;
            colorKeys[1].time = 0.14f * 1;
            colorKeys[2].time = 0.14f * 2;
            colorKeys[3].time = 0.14f * 3;
            colorKeys[4].time = 0.14f * 4;
            colorKeys[5].time = 0.14f * 5;
            colorKeys[6].time = 0.14f * 6;
            colorKeys[7].time = 1.0f;
            g.SetKeys(colorKeys, alphaKeys);
        }

        t = Mathf.Clamp01(t/ (of - 1));
        return g.Evaluate(t);
    }

    public static float Remap(this float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }

    public static Vector2 VectorFromAngleRads(float angle)
    {
        Vector2 V = new Vector2();
        V.x = Mathf.Cos(angle);
        V.y = Mathf.Sin(angle);
        return V.normalized;
    }

    public static Vector2 VectorFromAngle(float angle)
    {
        angle = Mathf.Deg2Rad * angle;
        return VectorFromAngleRads(angle).normalized;
    }

    public static float AngleFromVector(Vector2 dir)
    {
        float angle = Mathf.Rad2Deg * Mathf.Atan2(dir.y , dir.x);
        if(angle < 0)
        {
            angle += 360;
        }
        return angle;
    }
    public static float AngleFromVectorRads(Vector2 dir)
    {
        var angle = Mathf.Atan2(dir.y , dir.x);
        if (angle < 0)
        {
            angle += 2 * Mathf.PI;
        }
        return angle;
    }

    public static Vector2 PerpendicularClockwise(this Vector2 vec)
    {
        return new Vector2(vec.y, -vec.x);
    }

    public static Vector2 PerpendicularCounterClockwise(this Vector2 vec)
    {
        return new Vector2(-vec.y, vec.x);
    }


    //the wrap clamp maxValue is EXCLUSIVE so
    //WrapClamp(4, 0, 5) = 4
    //WrapClamp(5, 0, 5) = 0
    public static int WrapClamp(int value, int minValue, int maxValue)
    {
        if (value < minValue)
        {
            value = maxValue - Mathf.Abs(minValue - value);
        }

        if (value >= maxValue)
        {
            value = minValue + (value - maxValue);
        }
        return value;
    }

    /// <summary>
    /// Clamp a value and wrap around to based on the difference
    ///
    /// the wrap clamp maxValue is EXCLUSIVE so 
    /// WrapClamp(0, 5, 4.99f) = 4.99f
    /// WrapClamp(0, 5, 5.00f) = 0.0f
    /// </summary>
    /// <param name="minValue"></param>
    /// <param name="maxValue"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static float WrapClamp(float minValue, float maxValue, float value)
    {
        //prevent issues where the min and max are the same
        if (minValue == maxValue)
        {
            return minValue;
        }

        //swap the values if they're entered wrong.
        if(minValue > maxValue)
        {
            Debug.LogErrorFormat("Wrap Clamp's minValue {0} is greater than it's maxValue {1}, we've swapped the values.", minValue, maxValue);
            var temp = minValue;
            minValue = maxValue;
            maxValue = temp;
        }

        if (value < minValue)
        {
            value = maxValue - Mathf.Abs(minValue - value);
        }

        if (value >= maxValue)
        {
            value = minValue + (value - maxValue);
        }

        //recurse if we're still outside the range.
        if (value >= maxValue || value < minValue)
        {
            value = WrapClamp(minValue, maxValue, value);
        }

        return value;
    }


    public static float AngleTo(this Vector2 self, Vector2 to)
    {
        Vector2 direction = to - self;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0f) angle += 360f;
        return angle;
    }
}

