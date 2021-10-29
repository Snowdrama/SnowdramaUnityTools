using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioList", menuName = "GameData/AudioList")]
public class AudioClipList : GameData
{
    [SerializeField]
    private List<GameAudioClip> _clips;
    private int lastClipPlayed = 0;
    
    public List<GameAudioClip> Value
    {
        get
        {
            return _clips;
        }
        set
        {
            _clips = value;
            this.OnDataChanged?.OnEvent?.Invoke();
        }
    }

    /// <summary>
    /// Gets a clip from the list
    /// </summary>
    /// <param name="index">The index of the clip</param>
    public GameAudioClip GetClip(int index)
    {
        if(index >= 0 && index < _clips.Count)
        {
            return _clips[index];
        }
        Debug.LogError("Index does not exist in clip list: " + this.name);
        return null;
    }

    /// <summary>
    /// Gets a random GameAudioClip from a list that contains an audio clip, a volume and a pitch
    /// </summary>
    public GameAudioClip GetRandomClip()
    {
        int index = Random.Range(0, _clips.Count);
        if (_clips.Count > 1)
        {
            //since we have 2 or more audio clips, let's make sure we never play the same index
            while (index == lastClipPlayed)
            {
                index = Random.Range(0, _clips.Count);
            }
            return GetClip(index);
        }
        //since there's only 1 in the list then just return index 0
        return GetClip(0);
    }

    /// <summary>
    /// Gets a random GameAudioClip from a list based on the clips weight defined in the ScriptableObject
    /// </summary>
    public GameAudioClip GetRandomWeightedAudioClip()
    {
        if (_clips.Count > 1)
        {
            float totalWeight = 0;
            for (int i = 0; i < _clips.Count; ++i)
            {
                totalWeight += _clips[i].Weight;
            }
            float pick = Random.Range(0, totalWeight);

            int index = Random.Range(0, _clips.Count);
            for (int i = 0; i < _clips.Count; ++i)
            {
                if (pick > _clips[i].Weight)
                {
                    pick -= _clips[i].Weight;
                    continue;
                }
                return _clips[i];
            }
        }
        //since there's only 1 in the list then just return index 0
        return GetClip(0);
    }

    /// <summary>
    /// Plays a random clip on the provided AudioSource
    /// </summary>
    /// <param name="source">The AudioSource to play the clip</param>
    public void PlayRandomClip(AudioSource source)
    {
        if (_clips.Count > 0)
        {
            var clip = GetRandomClip();
            source.clip = clip.Clip;
            source.volume = Random.Range(clip.VolumeMin, clip.VolumeMax);
            source.volume = Random.Range(clip.PitchMin, clip.PitchMax);
            source.loop = false; //I'm assuming we don't need this but it's a safety so it does play explosion.wav 5 times a second.
            source.Play();
            return;
        }
        Debug.LogError("AudioClipList " + this.name + " Does not have any clips to play");
    }
}
