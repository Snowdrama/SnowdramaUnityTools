using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundOnStart : MonoBehaviour
{
    [SerializeField] List<AudioClip> sounds;
    AudioSource source = null;
    // Start is called before the first frame update
    void Start()
    {
        source = this.GetComponent<AudioSource>();
        if (sounds.Count > 0)
        {
            source.clip = sounds[Random.Range(0, sounds.Count)];
            source.Play();
        }
    }
}
