using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowEditorUtils : MonoBehaviour
{
    /// <summary>
    /// Turns any system path that maps to something in the project to one that's relative.
    /// </summary>
    /// <param name="path">Some system path</param>
    /// <returns></returns>
    public static string ConvertPathToAssetPath(string path)
    {
        if (path.Contains("/Assets"))
        {
            int splitLocation = path.IndexOf("/Assets") + 1; //plus one so it's after the slash
            string newPath = path.Substring(splitLocation);
            return newPath;
        }
        return null;
    } 

    public static void UIButton(string buttonName, Action<GameObject> buttonAction, GameObject parameter)
    {
        if (GUILayout.Button(buttonName))
        {
            buttonAction.Invoke(parameter);
        }
    }
    public static void UIButton(string buttonName, Action<List<GameObject>> buttonAction, List<GameObject> parameter)
    {
        if (GUILayout.Button(buttonName))
        {
            buttonAction.Invoke(parameter);
        }
    }
    public static void UIButton<T, J>(string buttonName, Action<Dictionary<T, J>> buttonAction, Dictionary<T, J> parameter)
    {
        if (GUILayout.Button(buttonName))
        {
            buttonAction.Invoke(parameter);
        }
    }
    public static void UIButton(string buttonName, Action<string> buttonAction, string parameter)
    {
        if (GUILayout.Button(buttonName))
        {
            buttonAction.Invoke(parameter);
        }
    }
    public static void UIButton(string buttonName, Action<int> buttonAction, int parameter)
    {
        if (GUILayout.Button(buttonName))
        {
            buttonAction.Invoke(parameter);
        }
    }
    public static void UIButton(string buttonName, Action<uint> buttonAction, uint parameter)
    {
        if (GUILayout.Button(buttonName))
        {
            buttonAction.Invoke(parameter);
        }
    }
    public static void UIButton(string buttonName, Action<long> buttonAction, long parameter)
    {
        if (GUILayout.Button(buttonName))
        {
            buttonAction.Invoke(parameter);
        }
    }
    public static void UIButton(string buttonName, Action<bool> buttonAction, bool parameter)
    {
        if (GUILayout.Button(buttonName))
        {
            buttonAction.Invoke(parameter);
        }
    }
    public static void UIButton(string buttonName, Action<float> buttonAction, float parameter)
    {
        if (GUILayout.Button(buttonName))
        {
            buttonAction.Invoke(parameter);
        }
    }
    public static void UIButton(string buttonName, Action<char> buttonAction, char parameter)
    {
        if (GUILayout.Button(buttonName))
        {
            buttonAction.Invoke(parameter);
        }
    }
    public static void UIButton(string buttonName, Action<object> buttonAction, object parameters)
    {
        if (GUILayout.Button(buttonName))
        {
            buttonAction.Invoke(parameters);
        }
    }
    public static void UIButton(string buttonName, Action buttonAction)
    {
        if (GUILayout.Button(buttonName))
        {
            buttonAction.Invoke();
        }
    }

}
