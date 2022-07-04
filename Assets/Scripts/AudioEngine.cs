using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
    public AudioClip clip;
    
    [HideInInspector]
    public AudioSource source;

    public string name;
   
    [Range(0f, 1f)] 
    public float volume;

    public bool loop;
}


public class AudioEngine : MonoBehaviour
{
    public Sound[] sounds;
    
    private void Awake()
    {
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
        } 
    }

    private void Start()
    {
        Play("theme");
    }
    public void Play(string soundName)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == soundName);

        if (sound == null)
        {
            return;
        }

        if (!sound.source.isPlaying)
        {
            sound.source.Play();   
        }
        
    }
}
