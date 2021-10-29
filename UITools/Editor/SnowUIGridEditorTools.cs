using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Snowdrama.UI;

namespace Snowdrama.UI
{
    public class SnowUIGridEditorTools
    {
        [MenuItem("Snow/UI Grid Refresh #R")]
        public static void ForceAllUIGridsToUpdate()
        {
            var allGrids = GameObject.FindObjectsOfType<SnowUIGrid>();
            Debug.LogErrorFormat("All Grids Found {0}", allGrids.Length);
            foreach (var item in allGrids)
            {
                item.UpdateGrid();
            }
        }
    }
}
