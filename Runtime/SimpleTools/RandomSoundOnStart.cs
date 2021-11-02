using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snow.SimpleTools
{
    public class RandomSoundOnStart : MonoBehaviour
    {
        [SerializeField] List<AudioClip> sounds;
        AudioSource source = null;
        // Start is called before the first frame update
        void Start()
        {
            source = GetComponent<AudioSource>();
            if (sounds.Count > 0)
            {
                source.clip = sounds[Random.Range(0, sounds.Count)];
                source.Play();
            }
        }
    }
}