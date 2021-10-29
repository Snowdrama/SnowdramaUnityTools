using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This is an infinite grid, you can choose a direction of horizontal or vertical
 * and some value for which direction you want it to build in, forward or reverse
 * this will create a grid that increases in size based on the number of elements
 **/
namespace Snowdrama.UI
{
    [ExecuteInEditMode]
    public class SnowUIGridInfinite : MonoBehaviour
    {
        public enum InfiniteDirection
        {
            Horizontal,
            Vertical,
        }
        public InfiniteDirection infiniteDirection;
        public enum BuildDirection
        {
            //start at the top and build down or(top left is 0)
            //start at the left and build right(top left is 0)
            Forward,
            //start at the bottom and build up or(bottom left is 0)
            //start at the right and build left(top right is 0)
            Reverse,
        }
        public BuildDirection buildDirection;

        //one of these is derrived from the other depending on direction.
        public int numberOfSpacesAcross = 4;
        public float sizeInPixelsAgainst = 50f;

        [EditorReadOnly] public List<RectTransform> children = new List<RectTransform>();

        [Header("Debug")]
        public bool forceUpdate = false;
        public float percentSizeAcross = 0;
        public float percentSizeAgainst = 0;
        public int cellsTall;
        public float targetHeight;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (forceUpdate || transform.childCount != children.Count)
            {
                forceUpdate = false;
                children.Clear();
                foreach (Transform child in transform)
                {
                    children.Add(child.GetComponent<RectTransform>());
                }
                int indexAcross = 0;
                int indexAgainst = 0;
                percentSizeAcross = 1.0f / numberOfSpacesAcross;
                cellsTall = Mathf.CeilToInt((float)children.Count / (float)numberOfSpacesAcross);
                percentSizeAgainst = 1.0f / cellsTall;

                //Debug.LogFormat("{0}/{1} = Mathf.Ciel({2})", children.Count, numberOfSpacesAcross, (float)children.Count / (float)numberOfSpacesAcross);
                targetHeight = cellsTall * sizeInPixelsAgainst;

                this.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, targetHeight);


                foreach (var child in children)
                {
                    switch (infiniteDirection)
                    {
                        case InfiniteDirection.Horizontal:
                            switch (buildDirection)
                            {
                                case BuildDirection.Forward:
                                    TopToBottom_LeftToRight(child, indexAcross, indexAgainst);
                                    break;
                                case BuildDirection.Reverse:
                                    TopToBottom_RightToLeft(child, indexAcross, indexAgainst);
                                    break;
                                default:
                                    break;
                            }
                            child.offsetMin = Vector2.zero;
                            child.offsetMax = Vector2.zero;
                            break;

                        case InfiniteDirection.Vertical:
                            switch (buildDirection)
                            {
                                case BuildDirection.Forward:
                                    LeftToRight_TopToBottom(child, indexAcross, indexAgainst);
                                    break;
                                case BuildDirection.Reverse:
                                    LeftToRight_BottomToTop(child, indexAcross, indexAgainst);
                                    break;
                                default:
                                    break;
                            }
                            break;

                        default:
                            break;
                    }
                    indexAcross++;
                    if(indexAcross >= numberOfSpacesAcross)
                    {
                        indexAcross -= numberOfSpacesAcross;
                        indexAgainst++;
                    }
                }
            }
        }
        public void TopToBottom_LeftToRight(RectTransform child, int indexAcross, int indexAgainst)
        {
            Debug.LogError("This isn't implemented yet! Sorry!", this.gameObject);
        }

        public void TopToBottom_RightToLeft(RectTransform child, int indexAcross, int indexAgainst)
        {
            Debug.LogError("This isn't implemented yet! Sorry!", this.gameObject);
        }

        public void LeftToRight_BottomToTop(RectTransform child, int indexAcross, int indexAgainst)
        {
            child.anchorMin = new Vector2(
                indexAcross * percentSizeAcross,
                indexAgainst * percentSizeAgainst
                );

            child.anchorMax = new Vector2(
                (indexAcross + 1) * percentSizeAcross,
                (indexAgainst + 1) * percentSizeAgainst
                );
            child.offsetMin = Vector2.zero;
            child.offsetMax = Vector2.zero;
        }

        public void LeftToRight_TopToBottom(RectTransform child, int indexAcross, int indexAgainst)
        {
            child.anchorMin = new Vector2(
                indexAcross * percentSizeAcross,
                1 - ((indexAgainst + 1) * percentSizeAgainst)
                );

            child.anchorMax = new Vector2(
                (indexAcross + 1) * percentSizeAcross,
                1 - (indexAgainst * percentSizeAgainst)
                );
            child.offsetMin = Vector2.zero;
            child.offsetMax = Vector2.zero;
        }
    }
}