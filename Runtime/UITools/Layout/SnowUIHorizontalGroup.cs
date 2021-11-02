using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama.UI
{
    /// <summary>
    /// This class fits all the children into the current RectTransform
    /// Use SnowUIContentFitter if you need the RectTransform to fit
    /// to the size of the children
    /// </summary>
    [ExecuteInEditMode]
    public class SnowUIHorizontalGroup : MonoBehaviour
    {
        [Header("Gap")]
        public float gapX = 0.1f;
        public float gapY = 0.1f;
        [Header("Force Update")]
        public bool forceUpdate = false;
        public List<RectTransform> children = new List<RectTransform>();
        void Update()
        {
            if (transform.childCount != children.Count || forceUpdate)
            {
                children.Clear();
                foreach (Transform child in transform)
                {
                    children.Add(child.GetComponent<RectTransform>());
                }
                if (children.Count > 0)
                {
                    float percentWidth = 1.0f / children.Count;
                    for (int i = 0; i < children.Count; i++)
                    {
                        children[i].anchorMin = new Vector2((percentWidth * (i + 0)) + (gapX / 2), 0 + (gapY / 2));
                        children[i].anchorMax = new Vector2((percentWidth * (i + 1)) - (gapX / 2), 1 - (gapY / 2));
                        children[i].offsetMin = new Vector2(0, 0);
                        children[i].offsetMax = new Vector2(0, 0);
                    }
                }
            }
        }
    }
}