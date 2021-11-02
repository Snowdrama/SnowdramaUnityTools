using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama.UI
{
    [ExecuteInEditMode]
    public class SnowUIVerticalFlex : MonoBehaviour
    {
        [SerializeField] bool topToBottom;
        bool topToBottom_current = false;
        [SerializeField] bool reverseOrder;
        bool reverseOrder_current = false;
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

        [Header("Debug")]
        public List<RectTransform> children = new List<RectTransform>();
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            bool valuesChanged = false;
            foreach (var size in percentWidths)
            {
                if (size.HashChanged())
                {
                    valuesChanged = true;
                }
            }
            if (transform.childCount != children.Count ||
                topToBottom_current != topToBottom ||
                reverseOrder_current != reverseOrder ||
                valuesChanged)
            {
                topToBottom_current = topToBottom;
                reverseOrder_current = reverseOrder;
                children.Clear();
                foreach (Transform child in transform)
                {
                    children.Add(child.GetComponent<RectTransform>());
                }

                List<RectTransform> activeElements = children.Take(percentWidths.Count).ToList();
                List<RectTransform> elementsToDisable = children.Where(x => !activeElements.Contains(x)).ToList();

                foreach (var e in activeElements)
                {
                    e.gameObject.SetActive(true);
                }

                foreach (var e in elementsToDisable)
                {
                    e.gameObject.SetActive(false);
                }

                if (reverseOrder)
                {
                    activeElements.Reverse();
                }

                if (activeElements.Count > 0)
                {
                    var currentWidth = 0.0f;
                    for (int i = 0; i < activeElements.Count; i++)
                    {
                        currentWidth = UpdateElements(activeElements[i], percentWidths[i], currentWidth);
                    }
                }
            }
        }

        public float UpdateElements(RectTransform element, SnowUIFlexBox box, float currentWidth)
        {
            if (element != null)
            {
                if (topToBottom)
                {
                    element.anchorMin = new Vector2(0, 1 - (currentWidth + box.width));
                    element.anchorMax = new Vector2(1, 1 - (currentWidth));
                }
                else
                {
                    element.anchorMin = new Vector2(0, (currentWidth));
                    element.anchorMax = new Vector2(1, (currentWidth + box.width));
                }
                element.offsetMin = new Vector2(0, 0);
                element.offsetMax = new Vector2(0, 0);

                currentWidth += box.margin_top + box.width + box.margin_bottom;
            }
            return currentWidth;
        }
    }
}