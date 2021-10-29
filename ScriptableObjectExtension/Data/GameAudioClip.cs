using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameAudioClip
{
    public AudioClip Clip;
    public float VolumeMin = 1;
    public float VolumeMax = 1;
    public float PitchMin = 1;
    public float PitchMax = 1;
    public float Weight = 1;
}