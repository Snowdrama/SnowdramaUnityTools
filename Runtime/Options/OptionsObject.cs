using System;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OptionsObject", menuName = "OptionsObject")]
public class OptionsObject : ScriptableObject
{
    public List<FloatOption> defaultFloats = new List<FloatOption>();
    public List<IntOption> defaultInts = new List<IntOption>();
    public List<BoolOption> defaultBools = new List<BoolOption>();

    public Dictionary<string, int> intValues;
    public Dictionary<string, float> floatValues;
    public Dictionary<string, bool> boolValues;

    [Header("Debug [Edits Do Nothing]")]
    public List<FloatOption> debugFloats = new List<FloatOption>();
    public List<IntOption> debugInts = new List<IntOption>();
    public List<BoolOption> debugBools = new List<BoolOption>();

    public void Save()
    {
        Debug.Log("Saving Player Prefs");

        foreach (var item in intValues)
        {
            PlayerPrefs.SetInt(item.Key, item.Value);
        }
        foreach (var item in floatValues)
        {
            PlayerPrefs.SetFloat(item.Key, item.Value);
        }
        foreach (var item in boolValues)
        {
            PlayerPrefs.SetInt(item.Key, (item.Value) ? 1 : 0);
        }
        UpdateDebug();
    }

    public void Load()
    {
        if (intValues == null) { intValues = new Dictionary<string, int>(); }
        if (floatValues == null) { floatValues = new Dictionary<string, float>(); }
        if (boolValues == null) { boolValues = new Dictionary<string, bool>(); }

        foreach (var item in defaultInts)
        {
            var value = PlayerPrefs.GetInt(item.name, item.defaultValue);
            if (intValues.ContainsKey(item.name))
            {
                intValues[item.name] = value;
            }
            else
            {
                intValues.Add(item.name, value);
            }
        }
        foreach (var item in defaultFloats)
        {
            var value = PlayerPrefs.GetFloat(item.name, item.defaultValue);
            if (floatValues.ContainsKey(item.name))
            {
                floatValues[item.name] = value;
            }
            else
            {
                floatValues.Add(item.name, value);
            }
        }
        foreach (var item in defaultBools)
        {
            var defaultValue = (item.defaultValue) ? 1 : 0;
            var value = (PlayerPrefs.GetInt(item.name, defaultValue) == 1) ? true : false;
            if (boolValues.ContainsKey(item.name))
            {
                boolValues[item.name] = value;
            }
            else
            {
                boolValues.Add(item.name, value);
            }
        }
        UpdateDebug();
    }

    public void SetIntValue(string name, int value)
    {
        if (intValues.ContainsKey(name))
        {
            intValues[name] = value;
        }
        else
        {
            intValues.Add(name, value);
        }
        Save();
    }

    public int GetIntValue(string name, int defaultValue = 0)
    {
        if (intValues.ContainsKey(name))
        {
            return intValues[name];
        }
        else
        {
            return defaultValue;
        }
    }

    public void SetBoolValue(string name, bool value)
    {
        if (boolValues.ContainsKey(name))
        {
            boolValues[name] = value;
        }
        else
        {
            boolValues.Add(name, value);
        }
        Save();
    }

    public bool GetBoolValue(string name, bool defaultValue = false)
    {
        if (boolValues.ContainsKey(name))
        {
            return boolValues[name];
        }
        else
        {
            return defaultValue;
        }
    }

    public void SetFloatValue(string name, float value)
    {
        if (floatValues.ContainsKey(name))
        {
            floatValues[name] = value;
        }
        else
        {
            floatValues.Add(name, value);
        }
        Save();
    }

    public float GetFloatValue(string name, float defaultValue = 0.0f)
    {
        if (floatValues.ContainsKey(name))
        {
            return floatValues[name];
        }
        else
        {
            return defaultValue;
        }
    }

    [System.NonSerialized] bool initialized;
    public void OnEnable()
    {
        if (!initialized)
        {
            Load();
        }
    }

    private void OnDisable()
    {
        Save();
    }

    public void UpdateDebug()
    {
        debugInts = new List<IntOption>();
        foreach (var item in intValues)
        {
            var key = item.Key;
            var value = item.Value;
            debugInts.Add(new IntOption()
            {
                name = key,
                defaultValue = value
            });
        }
        debugFloats = new List<FloatOption>();
        foreach (var item in floatValues)
        {
            var key = item.Key;
            var value = item.Value;
            debugFloats.Add(new FloatOption()
            {
                name = key,
                defaultValue = value
            });
        }
        debugBools = new List<BoolOption>();
        foreach (var item in boolValues)
        {
            var key = item.Key;
            var value = item.Value;
            debugBools.Add(new BoolOption()
            {
                name = key,
                defaultValue = value
            });
        }
    }
}

[System.Serializable]
public struct FloatOption
{
    public string name;
    public float defaultValue;
}
[System.Serializable]
public struct IntOption
{
    public string name;
    public int defaultValue;
}
[System.Serializable]
public struct BoolOption
{
    public string name;
    public bool defaultValue;
}
