using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snowdrama.UI
{
    [ExecuteInEditMode]
    public class SnowUIGrid : MonoBehaviour
    {
        [System.Serializable]
        public struct GridCell
        {
            public Color color;
            public int cellId;
            public int width;
            public int height;
            //unity uses for anchors
            public Vector2Int bottomLeftCell;
            public Vector2Int topRightCell;
        }

        public Sprite palette;
        public Dictionary<Color, int> paletteList = new Dictionary<Color, int>();
        public Sprite styleSprite;
        private string oldStyles;
        public float topPadding = 0.0f;
        public float botPadding = 0.0f;
        public float leftPadding = 0.0f;
        public float rightPadding = 0.0f;

        [Header("Derrived")]
        [EditorReadOnly] public int width;
        [EditorReadOnly] public int height;
        [EditorReadOnly] public float percentWidthCell;
        [EditorReadOnly] public float percentHeightCell;
        [EditorReadOnly] public Dictionary<int, GridCell> gridCells = new Dictionary<int, GridCell>();
        [EditorReadOnly] public List<RectTransform> children = new List<RectTransform>();

        [Header("Debug")]
        public bool forceUpdate = false;
        [EditorReadOnly] public List<Color> debugPaletteKeys = new List<Color>();
        [EditorReadOnly] public List<int> debugPaletteValues = new List<int>();

        [EditorReadOnly] public List<int> debugKeys = new List<int>();
        [EditorReadOnly] public List<GridCell> debugCells = new List<GridCell>();

#if UNITY_EDITOR
        // Start is called before the first frame update
        void Start()
        {
            forceUpdate = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (forceUpdate || transform.childCount != children.Count)
            {
                UpdateGrid();
            }
        }

        public void UpdateGrid()
        {

            forceUpdate = false;
            int paletteIndex = -1;
            if (palette == null || styleSprite == null)
            {
                return;
            }
            for (int y = 0; y < palette.texture.height; y++)
            {
                for (int x = 0; x < palette.texture.width; x++)
                {
                    var color = palette.texture.GetPixel(x, y);
                    if (!paletteList.ContainsKey(color) && color.a >= 1.0f)
                    {
                        paletteList.Add(color, paletteIndex);
                        paletteIndex++;
                    }
                }
            }
            debugPaletteKeys = new List<Color>(paletteList.Keys);
            debugPaletteValues = new List<int>(paletteList.Values);

            //we assume a grid is always square so take the first row/column
            percentHeightCell = 1.0f / styleSprite.texture.height;
            percentWidthCell = 1.0f / styleSprite.texture.width;

            gridCells.Clear();
            for (int y = 0; y < styleSprite.texture.height; y++)
            {
                for (int x = 0; x < styleSprite.texture.width; x++)
                {
                    int cellID = -1;
                    var colorKey = styleSprite.texture.GetPixel(x, y);
                    if (paletteList.ContainsKey(colorKey))
                    {
                        cellID = paletteList[colorKey];
                    }
                    if (cellID >= 0)
                    {
                        if (gridCells.ContainsKey(cellID))
                        {
                            //a grid already exists for this
                            GridCell cell = gridCells[cellID];
                            cell.color = colorKey;
                            if (x < cell.bottomLeftCell.x)
                            {
                                cell.bottomLeftCell.x = x;
                            }
                            if (y < cell.bottomLeftCell.y)
                            {
                                cell.bottomLeftCell.x = y;
                            }

                            if (x + 1 > cell.topRightCell.x)
                            {
                                cell.topRightCell.x = x + 1;
                            }
                            if (y + 1 > cell.topRightCell.y)
                            {
                                cell.topRightCell.y = y + 1;
                            }
                            cell.width = cell.topRightCell.x - cell.bottomLeftCell.x;
                            cell.height = cell.topRightCell.y - cell.bottomLeftCell.y;
                            gridCells[cellID] = cell;
                        }
                        else
                        {
                            GridCell tempCell = new GridCell();
                            tempCell.color = colorKey;
                            tempCell.cellId = cellID;
                            tempCell.bottomLeftCell = new Vector2Int(x, y);
                            tempCell.topRightCell = new Vector2Int(x + 1, y + 1);
                            gridCells.Add(cellID, tempCell);
                        }
                    }
                }
            }
            debugKeys = new List<int>(gridCells.Keys);
            debugCells = new List<GridCell>(gridCells.Values);

            for (int i = 0; i < gridCells.Keys.Count; i++)
            {
                if (!gridCells.ContainsKey(i))
                {
                    Debug.LogErrorFormat("Grid cells skip index {0}!", i);
                    Debug.Log("Skipped Cells", this.gameObject);
                    return;
                }
            }

            children.Clear();
            foreach (Transform child in transform)
            {
                children.Add(child.GetComponent<RectTransform>());
            }

            for (int i = 0; i < children.Count; i++)
            {
                if (gridCells.ContainsKey(i))
                {
                    GridCell cell = gridCells[i];

                    children[i].anchorMin = new Vector2(
                        cell.bottomLeftCell.x * percentWidthCell,
                        cell.bottomLeftCell.y * percentHeightCell
                        );
                    children[i].anchorMax = new Vector2(
                        cell.topRightCell.x * percentWidthCell,
                        cell.topRightCell.y * percentHeightCell
                        );
                    children[i].offsetMin = new Vector2(leftPadding, botPadding);
                    children[i].offsetMax = new Vector2(-rightPadding, -topPadding);
                }
            }
        }
#endif
    }
}