using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama.UI
{
    [ExecuteInEditMode]
    public class SnowUIHorizontalFlex : MonoBehaviour
    {
        [SerializeField] string values;
        [SerializeField]
        List<SnowUIFlexBox> percentWidths = new List<SnowUIFlexBox>()
    {
        new SnowUIFlexBox()
        {
            width = 0.25f,
        },
        new SnowUIFlexBox()
        {
            width = 0.75f,
        },
    };

        List<SnowUIFlexBox> oldPercentWidths = new List<SnowUIFlexBox>();
        [Header("Force Update")]
        public bool forceUpdate = false;
        public List<RectTransform> children = new List<RectTransform>();
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            bool valuesChanged = false;
            if (oldPercentWidths.Count == percentWidths.Count)
            {
                for (int i = 0; i < oldPercentWidths.Count; i++)
                {
                    if (percentWidths[i].width != oldPercentWidths[i].width)
                    {
                        valuesChanged = true;
                        break;
                    }
                }
            }
            else
            {
                valuesChanged = true;
            }
            if (transform.childCount != children.Count || forceUpdate || valuesChanged)
            {
                forceUpdate = false;
                children.Clear();
                foreach (Transform child in transform)
                {
                    children.Add(child.GetComponent<RectTransform>());
                }
                if (children.Count > 0)
                {
                    var currentWidth = 0.0f;
                    for (int i = 0; i < children.Count; i++)
                    {
                        if (children[i].gameObject.activeSelf)
                        {
                            var anchorMinX = currentWidth + percentWidths[i].margin_left;
                            var anchorMaxX = currentWidth + percentWidths[i].width - percentWidths[i].margin_right;
                            children[i].anchorMin = new Vector2(anchorMinX, 0 + percentWidths[i].margin_bottom);
                            children[i].anchorMax = new Vector2(anchorMaxX, 1 - percentWidths[i].margin_top);
                            children[i].offsetMin = new Vector2(0, 0);
                            children[i].offsetMax = new Vector2(0, 0);

                            currentWidth += percentWidths[i].width;

                            percentWidths[i].totalWidth = percentWidths[i].margin_left + percentWidths[i].width + percentWidths[i].margin_right;
                            percentWidths[i].totalHeight = 1;
                        }
                    }
                }
            }
        }
    }
}