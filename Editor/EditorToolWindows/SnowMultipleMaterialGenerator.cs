using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/**
 * Basically the goal is to be able to select a folder
 * Then create a material based on the textures. 
 * 
 * We search the folders for textures with:
 * 
 * diffuse
 * normal
 * specular
 * etc
 * 
 * in the name then we make a material asset from it. 
 * 
 * If it doesn't have that in the name, then we assume it's a diffuse
 * texture.
 * 
 * TODO: Check the unity type to see if it's labeled as a normal map
 **/

public class SnowMultipleMaterialGenerator : EditorWindow
{
    private Texture2D DiffuseTexture;
    private Texture2D NormalTexture;
    private Texture2D HeightTexture;
    private Texture2D MetallicSpecularTexture;
    private Texture2D EmissionTexture;
    private Texture2D OcclusionTexture;

    private bool toggleOptionalMaterial;
    private Material StarterMaterial;

    private string lastPath;
    private bool metalic;
    private bool specular;

    [MenuItem("Snow/Multiple Diffuse Material Generator")]
    public static void ShowWindow()
    {
        GetWindow<SnowMultipleMaterialGenerator>("Multiple Material Generator");
    }
    void OnGUI()
    {
        GUILayout.Label("Make Material From Textures", EditorStyles.boldLabel);
        GUILayout.Space(16.0f);
        GUILayout.Label("Get Textures:", EditorStyles.boldLabel);
        GUILayout.Label("Choose a folder to generate a material from the textures inside");
        GUILayout.Label("It will make a material for EACH texture.");
        GUILayout.Space(16.0f);
        toggleOptionalMaterial = EditorGUILayout.BeginToggleGroup("Starter Material(Optional)", toggleOptionalMaterial);
        GUILayout.Label("Choose a default material to copy the settings from.");
        StarterMaterial = (Material)EditorGUILayout.ObjectField(StarterMaterial, typeof(Material), false, new GUILayoutOption[0]);
        if (!toggleOptionalMaterial)
        {
            StarterMaterial = null;
        }
        EditorGUILayout.EndToggleGroup();
        GUILayout.Space(16.0f);
        SnowEditorUtils.UIButton("Load and Generate Materials", LoadMaterials);

    }

    public void CreateMaterial(Texture2D texture, string moddedPath, string fileName, string extension)
    {
        if (moddedPath != null)
        {
            Material mat;
            if (StarterMaterial != null)
            {
                mat = new Material(StarterMaterial);
            }
            else
            {
                mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            }

            mat.SetTexture("_BaseMap", texture);
            mat.SetTexture("_MainTex", texture);

            AssetDatabase.CreateAsset(mat, String.Format("{0}/{1}{2}", moddedPath, fileName, ".mat"));
            AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);
        }
    }

    public void LoadMaterials()
    {
        string path = EditorUtility.OpenFolderPanel("Load Textures", lastPath, "");
        if (path != null && path != "")
        {
            lastPath = path;
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                string extension = Path.GetExtension(file).ToLower();
                string fileName = Path.GetFileNameWithoutExtension(file);
                string moddedPath = SnowEditorUtils.ConvertPathToAssetPath(path);
                if (
                    extension.EndsWith(".png") ||
                    extension.EndsWith(".jpeg") ||
                    extension.EndsWith(".jpg") ||
                    extension.EndsWith(".tga")
                )
                {
                    Debug.Log(String.Format("{0}/{1}{2}", moddedPath, fileName, extension));
                    Texture2D tex = AssetDatabase.LoadAssetAtPath<Texture2D>(String.Format("{0}/{1}{2}", moddedPath, fileName, extension));
                    CreateMaterial(tex, moddedPath, fileName, extension);
                }
            }
        }
    }
}
