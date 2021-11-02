using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SnowSplitPrefabs : EditorWindow
{
    GameObject SelectedPrefab;
    string lastPath;

    [MenuItem("Snow/Split Prefabs")]
    public static void ShowWindow()
    {
        GetWindow<SnowSplitPrefabs>("Split Prefabs - Snow");
    }
    void OnGUI()
    {
        GUILayout.Label("Split Object Into Child Prefabs:", EditorStyles.boldLabel);
        GUILayout.Space(16.0f);
        GUILayout.Label("Drop a game Object Here then hit the button\nand choose where to save your GameObjects.\nAll direct children will become a prefab");
        SelectedPrefab = (GameObject)EditorGUILayout.ObjectField(SelectedPrefab, typeof(GameObject), true, new GUILayoutOption[0]);
        SnowEditorUtils.UIButton("Split To Prefabs", SplitToPrefabs);
    }

    public void SplitToPrefabs()
    {
        string path = EditorUtility.SaveFolderPanel("Save Prefabs", lastPath, "Save Folder");
        lastPath = path;
        if(path != null && path != "")
        {
            string moddedPath = SnowEditorUtils.ConvertPathToAssetPath(path);
            if(SelectedPrefab == null)
            {
                Debug.LogError("Dummy, you need to set a game object to split");
                return;
            }
            var instantiatedObject = (GameObject)Instantiate(SelectedPrefab, Vector3.zero, Quaternion.identity);
            foreach (Transform child in instantiatedObject.transform)
            {
                PrefabUtility.SaveAsPrefabAssetAndConnect(child.gameObject, string.Format("{0}/{1}{2}", moddedPath, child.name, ".prefab"), InteractionMode.AutomatedAction);
            }
            AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);
        }
    }
}
