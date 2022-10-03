using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GridMode
{
    ColumnsFirst,
    RowsFirst,
}
public enum GridMode_Columns
{
    Left_To_Right,
    Right_To_Left,
}
public enum GridMode_Rows
{
    Top_To_Bottom,
    Bottom_To_Top,
}
/// <summary>
/// This class fits all the children into the current RectTransform
/// Use SnowUIContentFitter if you need the RectTransform to fit
/// to the size of the children
/// </summary>
[ExecuteInEditMode]
public class SnowUIGridGroup : MonoBehaviour
{
    [Header("Columns & Rows")]
    [Range(1, 10)]
    public int columnCount = 1;
    [Range(1, 10)]
    public int rowCount = 1;
    [Header("Gap")]
    public float anchorGapX = 0.01f;
    public float anchorGapY = 0.01f;
    [Header("Percents")]
    public float percentWidth;
    public float percentHeight;
    [Header("Grid Direction")]
    public GridMode gridMode;
    public GridMode_Columns columnMode;
    public GridMode_Rows rowMode;
    [Header("Active Items")]
    public bool useActive;
    [Header("Force Update")]
    public bool forceUpdate = false;
    [Header("Children")]
    public List<RectTransform> children = new List<RectTransform>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.childCount != children.Count || forceUpdate == true)
        {
            children.Clear();
            foreach (Transform child in transform)
            {
                if (useActive)
                {
                    if (child.gameObject.activeSelf)
                    {
                        children.Add(child.GetComponent<RectTransform>());
                    }
                }
                else
                {
                    children.Add(child.GetComponent<RectTransform>());
                }
            }
            if (children.Count > 0)
            {
                if (children.Count > (rowCount * columnCount))
                {
                    Debug.LogError("Grid has more items than columns and rows");
                }
                percentWidth = 1.0f / columnCount;
                percentHeight = 1.0f / rowCount;


                if (columnMode == GridMode_Columns.Left_To_Right)
                {
                    if(rowMode == GridMode_Rows.Top_To_Bottom)
                    {
                        if(gridMode == GridMode.ColumnsFirst)
                        {
                            LTR_TTB();
                        }
                        else
                        {
                            TTB_LTR();
                        }
                    }
                    else if(rowMode == GridMode_Rows.Bottom_To_Top)
                    {
                        if (gridMode == GridMode.ColumnsFirst)
                        {
                            LTR_BTT();
                        }
                        else
                        {
                            BTT_LTR();
                        }
                    }
                }
            }
            else
            {
                //Debug.LogError("Grid contains no items to align must have at least one");
            }
        }
    }

    //ColumnsFirst Left-To-Right then Top-To-Bottom
    public void LTR_TTB()
    {
        float percentWidth_WithGap = percentWidth - (anchorGapX / 2);
        float percentHeight_WithGap = percentHeight - (anchorGapX / 2);
        for (int yPos = 0; yPos < rowCount; yPos++)
        {
            for (int xPos = 0; xPos < columnCount; xPos++)
            {
                int index = xPos + (yPos * columnCount);
                if (index < children.Count)
                {
                    float minX =     (percentWidth  * (xPos + 0)) + (anchorGapX / 2.0f);
                    float minY = 1 - (percentHeight * (yPos + 1)) + (anchorGapY / 2.0f);

                    float maxX =     (percentWidth  * (xPos + 1)) - (anchorGapX / 2.0f);
                    float maxY = 1 - (percentHeight * (yPos + 0)) - (anchorGapY / 2.0f);
                    children[index].anchorMin = new Vector2(minX, minY);
                    children[index].anchorMax = new Vector2(maxX, maxY);
                    children[index].offsetMin = new Vector2(0, 0);
                    children[index].offsetMax = new Vector2(0, 0);
                }
            }
        }
    }
    //RowsFirst Top-To-Bottom then Left-To-Right
    public void TTB_LTR()
    {
        for (int xPos = 0; xPos < columnCount; xPos++)
        {
            for (int yPos = 0; yPos < rowCount; yPos++)
            {
                int index = yPos + (xPos * columnCount);
                if (index < children.Count)
                {
                    children[index].anchorMin = new Vector2(percentWidth * (xPos + 0), 1 - percentHeight * (yPos + 1));
                    children[index].anchorMax = new Vector2(percentWidth * (xPos + 1), 1 - percentHeight * (yPos + 0));
                    children[index].offsetMin = new Vector2(0, 0);
                    children[index].offsetMax = new Vector2(0, 0);
                }
            }
        }
    }

    //Left-To-Right Bottom-To-Top
    public void LTR_BTT()
    {
        for (int yPos = 0; yPos < rowCount; yPos++)
        {
            for (int xPos = 0; xPos < columnCount; xPos++)
            {
                int index = xPos + (yPos * columnCount);
                if (index < children.Count)
                {
                    children[index].anchorMin = new Vector2(percentWidth * (xPos + 0), percentHeight * (yPos + 0));
                    children[index].anchorMax = new Vector2(percentWidth * (xPos + 1), percentHeight * (yPos + 1));
                    children[index].offsetMin = new Vector2(0, 0);
                    children[index].offsetMax = new Vector2(0, 0);
                }
            }
        }
    }
    //RowsFirst Bottom-To-Top then Left-To-Right
    public void BTT_LTR()
    {
        for (int yPos = 0; yPos < rowCount; yPos++)
        {
            for (int xPos = 0; xPos < columnCount; xPos++)
            {
                int index = xPos + (yPos * columnCount);
                if (index < children.Count)
                {
                    children[index].anchorMin = new Vector2(percentWidth * (xPos + 0), percentHeight * (yPos + 0));
                    children[index].anchorMax = new Vector2(percentWidth * (xPos + 1), percentHeight * (yPos + 1));
                    children[index].offsetMin = new Vector2(0, 0);
                    children[index].offsetMax = new Vector2(0, 0);
                }
            }
        }
    }
}
