using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAnimation : MonoBehaviour
{
    public float speed;
    public float offset;
    public float scale;

    public bool useX;
    public bool useY;
    public bool useZ;


    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var value = Mathf.Sin(offset + (Time.time * speed)) * scale;
        if (useX)
        {
            position.x = value;
        }
        if (useY)
        {
            position.y = value;
        }
        if (useZ)
        {
            position.z = value;
        }

        this.transform.localPosition = position;
    }
}
