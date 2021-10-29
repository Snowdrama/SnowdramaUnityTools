using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGizmo : MonoBehaviour
{
    [SerializeField] Color color = Color.cyan;
    [SerializeField] Vector3 size = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] bool wireBox = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        if (wireBox)
        {
            Gizmos.DrawWireCube(this.transform.position, size);
        }
        else
        {
            Gizmos.DrawCube(this.transform.position, size);
        }
    }
}
