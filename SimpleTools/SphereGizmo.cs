using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGizmo : MonoBehaviour
{
    [SerializeField] Color color = Color.cyan;
    [SerializeField] float radius = 0.5f;
    [SerializeField] bool wireSphere = false;
    [SerializeField] bool alwaysShow = true;

    private void OnDrawGizmosSelected()
    {
        if (!alwaysShow)
        {
            Gizmos.color = color;
            if (wireSphere)
            {
                Gizmos.DrawWireSphere(this.transform.position, radius);
            }
            else
            {
                Gizmos.DrawSphere(this.transform.position, radius);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if(alwaysShow)
        {
            Gizmos.color = color;
            if (wireSphere)
            {
                Gizmos.DrawWireSphere(this.transform.position, radius);
            }
            else
            {
                Gizmos.DrawSphere(this.transform.position, radius);
            }
        }
    }
}
