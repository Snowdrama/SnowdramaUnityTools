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

public class SnowMaterialGenerator : EditorWindow
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

    [MenuItem("Snow/Generate Material From Textures")]
    public static void ShowWindow()
    {
        GetWindow<SnowMaterialGenerator>("Snow Material Generator");
    }
    void OnGUI()
    {
        GUILayout.Label("Make Material From Textures", EditorStyles.boldLabel);
        GUILayout.Space(16.0f);
        GUILayout.Label("Get Textures:", EditorStyles.boldLabel);
        GUILayout.Label("Choose a folder to generate a material from the textures inside");
        SnowEditorUtils.UIButton("Load Textures", LoadMaterials);

        GUILayout.Space(16.0f);
        GUILayout.Label("Assigned Textures:", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Diffuse Texture");
        DiffuseTexture = (Texture2D)EditorGUILayout.ObjectField(DiffuseTexture, typeof(Texture2D), false, new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Metalic Texture");
        MetallicSpecularTexture = (Texture2D)EditorGUILayout.ObjectField(MetallicSpecularTexture, typeof(Texture2D), false, new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Normal Map");
        NormalTexture = (Texture2D)EditorGUILayout.ObjectField(NormalTexture, typeof(Texture2D), false, new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Height Map");
        HeightTexture = (Texture2D)EditorGUILayout.ObjectField(HeightTexture, typeof(Texture2D), false, new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Occlusion Map");
        OcclusionTexture = (Texture2D)EditorGUILayout.ObjectField(OcclusionTexture, typeof(Texture2D), false, new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Emission Map");
        EmissionTexture = (Texture2D)EditorGUILayout.ObjectField(EmissionTexture, typeof(Texture2D), false, new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        SnowEditorUtils.UIButton("Clear Textures", ClearMaterials);

        GUILayout.Space(16.0f);
        toggleOptionalMaterial = EditorGUILayout.BeginToggleGroup("Starter Material(Optional)", toggleOptionalMaterial);
        GUILayout.Label("Choose a default material to copy the settings from.");
        StarterMaterial = (Material)EditorGUILayout.ObjectField(StarterMaterial, typeof(Material), false, new GUILayoutOption[0]);
        if(!toggleOptionalMaterial)
        {
            StarterMaterial = null;
        }
        EditorGUILayout.EndToggleGroup();
        GUILayout.Space(16.0f);
        GUILayout.Label("Generate Material", EditorStyles.boldLabel);
        SnowEditorUtils.UIButton("Create Material", CreateMaterial);

    }
    public void ClearMaterials()
    {
        DiffuseTexture = null;
        NormalTexture = null;
        HeightTexture = null;
        MetallicSpecularTexture = null;
        EmissionTexture = null;
        OcclusionTexture = null;
    }

    public void CreateMaterial()
    {
        string path = EditorUtility.SaveFilePanel("Save Material", lastPath, "Material", "mat");
        string moddedPath = SnowEditorUtils.ConvertPathToAssetPath(path);

        if (moddedPath != null)
        {
            Material mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));

            if (DiffuseTexture != null)
            {
                mat.SetTexture("_BaseMap", DiffuseTexture);
                mat.SetTexture("_MainTex", DiffuseTexture);
            }
            if (NormalTexture != null)
            { 
                mat.SetTexture("_BumpMap", NormalTexture); 
            }
            if (HeightTexture != null)
            { 
                mat.SetTexture("_ParallaxMap", HeightTexture); 
            }
            if (MetallicSpecularTexture != null)
            {
                mat.SetTexture("_MetallicGlossMap", MetallicSpecularTexture);
                mat.SetTexture("_SpecGlossMap", MetallicSpecularTexture);
                if (metalic)
                {
                    mat.SetFloat("_WorkflowMode", 0);
                }
                else if (specular)
                {
                    mat.SetFloat("_WorkflowMode", 1);
                }
            }
            if (EmissionTexture != null)
            { 
                mat.SetTexture("_EmissionMap", EmissionTexture); 
            }
            if (OcclusionTexture != null)
            { 
                mat.SetTexture("_OcclusionMap", OcclusionTexture); 
            }

            AssetDatabase.CreateAsset(mat, moddedPath);
            AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);
        }
    }

    public void LoadMaterials()
    {
        string path = EditorUtility.OpenFolderPanel("Load Textures", lastPath, "");
        if(path != null && path != "")
        {
            lastPath = path;
            string[] files = Directory.GetFiles(path);
            ClearMaterials();
            foreach (string file in files)
            {
                string extension = Path.GetExtension(file).ToLower();
                string fileName = Path.GetFileNameWithoutExtension(file).ToLower();
                string moddedPath = SnowEditorUtils.ConvertPathToAssetPath(file);
                if (
                    extension.EndsWith(".png")  || 
                    extension.EndsWith(".jpeg") || 
                    extension.EndsWith(".jpg")  || 
                    extension.EndsWith(".tga")
                )
                {
                    if ((fileName.Contains("diffuse") || fileName.Contains("base")) && DiffuseTexture == null)
                    {
                        DiffuseTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(moddedPath);
                    }
                    if (fileName.Contains("normal") && NormalTexture == null)
                    {
                        NormalTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(moddedPath);
                    }
                    if (fileName.Contains("normal") && NormalTexture == null)
                    {
                        HeightTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(moddedPath);
                    }
                    if (fileName.Contains("height"))
                    {
                        HeightTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(moddedPath);
                    }
                    if (fileName.Contains("occlusion"))
                    {
                        OcclusionTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(moddedPath);
                    }
                    if (fileName.Contains("specular"))
                    {
                        specular = true;
                        metalic = false;
                        MetallicSpecularTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(moddedPath);
                    }
                    if (fileName.Contains("metallic"))
                    {
                        metalic = true;
                        specular = false;
                        MetallicSpecularTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(moddedPath);
                    }
                    if (fileName.Contains("emission"))
                    {
                        EmissionTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(moddedPath);
                    }
                }
            }
        }
    }
}
