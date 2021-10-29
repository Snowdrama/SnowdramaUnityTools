using System;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OptionsObject", menuName = "OptionsObject")]
public class OptionsObject : ScriptableObject
{
    //[NonSerialized] private float _masterVolume = 1.0f;
    //[EditorReadOnly] [SerializeField] private float _masterVolume_view;
    //public float MasterVolume
    //{
    //    get { return _masterVolume; }
    //    set
    //    {
    //        _masterVolume_view = value;
    //        _masterVolume = value;
    //        Save();
    //    }
    //}
    //[NonSerialized] private float _musicVolume = 1.0f;
    //[EditorReadOnly] [SerializeField] private float _musicVolume_view;
    //public float MusicVolume
    //{
    //    get { return _musicVolume; }
    //    set
    //    {
    //        _musicVolume_view = value;
    //        _musicVolume = value;
    //        Save();
    //    }
    //}
    //[NonSerialized] private float _soundVolume = 1.0f;
    //[EditorReadOnly] [SerializeField] private float _soundVolume_view;
    //public float SoundVolume
    //{
    //    get { return _soundVolume; }
    //    set
    //    {
    //        _soundVolume_view = value;
    //        _soundVolume = value;
    //        Save();
    //    }
    //}
    //[NonSerialized] private float _voiceVolume = 1.0f;
    //[EditorReadOnly] [SerializeField] private float _voiceVolume_view;
    //public float VoiceVolume
    //{
    //    get { return _voiceVolume; }
    //    set
    //    {
    //        _voiceVolume_view = value;
    //        _voiceVolume = value;
    //        Save();
    //    }
    //}

    //[NonSerialized] private float _mouseSensitivityX = 0.5f;
    //[EditorReadOnly] [SerializeField] private float _mouseSensitivityX_view;
    //public float MouseSensitivityX
    //{
    //    get { return _mouseSensitivityX; }
    //    set
    //    {
    //        _mouseSensitivityX_view = value;
    //        _mouseSensitivityX = value;
    //        Save();
    //    }
    //}
    //[NonSerialized] private float _mouseSensitivityY = 0.5f;
    //[EditorReadOnly] [SerializeField] private float _mouseSensitivityY_view;
    //public float MouseSensitivityY
    //{
    //    get { return _mouseSensitivityY; }
    //    set
    //    {
    //        _mouseSensitivityY_view = value;
    //        _mouseSensitivityY = value;
    //        Save();
    //    }
    //}

    //[NonSerialized] private float _gamepadSensitivityX = 0.5f;
    //[EditorReadOnly] [SerializeField] private float _gamepadSensitivityX_view;
    //public float GamepadSensitivityX
    //{
    //    get { return _gamepadSensitivityX; }
    //    set
    //    {
    //        _gamepadSensitivityX_view = value;
    //        _gamepadSensitivityX = value;
    //        Save();
    //    }
    //}
    //[NonSerialized] private float _gamepadSensitivityY = 0.5f;
    //[EditorReadOnly] [SerializeField] private float _gamepadSensitivityY_view;
    //public float GamepadSensitivityY
    //{
    //    get { return _gamepadSensitivityY; }
    //    set
    //    {
    //        _gamepadSensitivityY_view = value;
    //        _gamepadSensitivityY = value;
    //        Save();
    //    }
    //}

    //[NonSerialized] private bool _toggleHeadbob = true;
    //[EditorReadOnly] [SerializeField] private bool _toggleHeadbob_view;
    //public bool ToggleHeadbob
    //{
    //    get { return _toggleHeadbob; }
    //    set
    //    {
    //        _toggleHeadbob_view = value;
    //        _toggleHeadbob = value;
    //        Save();
    //    }
    //}

    //[NonSerialized] private bool _invertYAxis = false;
    //[EditorReadOnly] [SerializeField] private bool _invertYAxis_view;
    //public bool InvertYAxis
    //{
    //    get { return _invertYAxis; }
    //    set
    //    {
    //        _invertYAxis_view = value;
    //        _invertYAxis = value;
    //        Save();
    //    }
    //}

    //[NonSerialized] private bool _invertXAxis = false;
    //[EditorReadOnly] [SerializeField] private bool _invertXAxis_view;
    //public bool InvertXAxis
    //{
    //    get { return _invertXAxis; }
    //    set
    //    {
    //        _invertXAxis_view = value;
    //        _invertXAxis = value;
    //        Save();
    //    }
    //}


    //[NonSerialized] private bool _toggleSeasickness = true;
    //[EditorReadOnly][SerializeField] private bool _toggleSeasickness_view;
    //public bool ToggleSeasickness
    //{
    //    get { return _toggleSeasickness; }
    //    set
    //    {
    //        _toggleSeasickness_view = value;
    //        _toggleSeasickness = value;
    //        Save();
    //    }
    //}

    public List<FloatOption> defaultFloats;
    public List<IntOption> defaultInts;
    public List<BoolOption> defaultBools;

    public Dictionary<string, int> intValues;
    public Dictionary<string, float> floatValues;
    public Dictionary<string, bool> boolValues;

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
            PlayerPrefs.SetInt(item.Key, (item.Value)? 1 : 0);
        }
        //PlayerPrefs.SetFloat("MasterVolume", _masterVolume);
        //PlayerPrefs.SetFloat("MusicVolume", _musicVolume);
        //PlayerPrefs.SetFloat("SoundVolume", _soundVolume);
        //PlayerPrefs.SetFloat("VoiceVolume", _voiceVolume);

        //Debug.LogFormat("Mouse Senstivity X = {0}", _mouseSensitivityX);
        //Debug.LogFormat("Mouse Senstivity Y = {0}", _mouseSensitivityY);
        //PlayerPrefs.SetFloat("MouseSensitivityX", _mouseSensitivityX);
        //PlayerPrefs.SetFloat("MouseSensitivityY", _mouseSensitivityY);

        //PlayerPrefs.SetFloat("GamepadSensitivityX", _gamepadSensitivityX);
        //PlayerPrefs.SetFloat("GamepadSensitivityY", _gamepadSensitivityY);

        //PlayerPrefs.SetInt("InvertYAxis", (_invertYAxis) ? 1 : 0);
        //PlayerPrefs.SetInt("InvertXAxis", (_invertXAxis) ? 1 : 0);

        //PlayerPrefs.SetInt("ToggleSeasickness", (_toggleSeasickness) ? 1 : 0);
        //PlayerPrefs.SetInt("ToggleHeadbob", (_toggleHeadbob) ? 1 : 0);
    }

    public void Load()
    {
        Debug.Log("Loading Player Prefs");
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
            if(boolValues.ContainsKey(item.name))
            {
                boolValues[item.name] = value;
            }
            else
            {
                boolValues.Add(item.name, value);
            }
        }
        //_masterVolume_view = _masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1);
        //_musicVolume_view = _musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);
        //_soundVolume_view = _soundVolume = PlayerPrefs.GetFloat("SoundVolume", 1);
        //_voiceVolume_view = _voiceVolume = PlayerPrefs.GetFloat("VoiceVolume", 1);
        //_mouseSensitivityX_view = _mouseSensitivityX = PlayerPrefs.GetFloat("MouseSensitivityX", 0.5f);
        //_mouseSensitivityY_view = _mouseSensitivityY = PlayerPrefs.GetFloat("MouseSensitivityY", 0.5f);
        //_gamepadSensitivityX_view = _gamepadSensitivityX = PlayerPrefs.GetFloat("GamepadSensitivityX", 0.5f);
        //_gamepadSensitivityY_view = _gamepadSensitivityY = PlayerPrefs.GetFloat("GamepadSensitivityY", 0.5f);
        //_invertYAxis_view = _invertYAxis = PlayerPrefs.GetInt("InvertYAxis", 0) == 1 ? true : false;
        //_invertXAxis_view = _invertXAxis = PlayerPrefs.GetInt("InvertXAxis", 0) == 1 ? true : false;
        //_toggleSeasickness_view = _toggleSeasickness = PlayerPrefs.GetInt("ToggleSeasickness", 1) == 1 ? true : false;
        //_toggleHeadbob_view = _toggleHeadbob = PlayerPrefs.GetInt("ToggleHeadbob", 1) == 1 ? true : false;
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
        if(!initialized)
        {
            Load();
        }
    }

    private void OnDisable()
    {
        Save();
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
