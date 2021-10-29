using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama.UI
{
    /// <summary>
    /// This class changes the current RectTransform to match the size 
    /// of the children, this can either match by anchor or by size
    /// Use SnowUIContentFitter if you need the RectTransform to fit
    /// to the size of the children
    /// </summary>
    [ExecuteInEditMode]
    public class SnowUIContentFitter : MonoBehaviour
    {
        [Header("Force Update")]
        [SerializeField] private bool forceUpdate = false;
        [Header("Children[Debug]")]
        [SerializeField] private List<RectTransform> children = new List<RectTransform>();
        void Update()
        {
            if (transform.childCount != children.Count || forceUpdate)
            {
                children.Clear();
                foreach (Transform child in transform)
                {
                    if (child.gameObject.activeSelf)
                    {
                        children.Add(child.GetComponent<RectTransform>());
                    }
                }
            }
        }
    }
}