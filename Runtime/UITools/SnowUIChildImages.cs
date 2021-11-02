using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Snowdrama.UI
{
    //Goes through each child looking for something that accepts an image
    //and adds an image
    [ExecuteInEditMode]
    public class SnowUIChildImages : MonoBehaviour
    {
        public List<Sprite> sprites;
        public bool forceUpdate = false;
        [EditorReadOnly] public List<RectTransform> children = new List<RectTransform>();
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


                int count = 0;
                foreach (Transform child in transform)
                {
                    if(count < sprites.Count)
                    {
                        Image image;
                        if (child.TryGetComponent<Image>(out image))
                        {
                            image.sprite = sprites[count];
                            count++;
                        }
                    }
                }
            }
        }
    }
}