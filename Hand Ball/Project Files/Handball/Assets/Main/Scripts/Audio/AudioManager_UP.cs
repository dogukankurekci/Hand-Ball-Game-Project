using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager_UP : MonoBehaviour
{
    public Sounds_UP[] sounds;

    void Awake()
    {
        foreach (Sounds_UP s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    public void Play(string name)
    {
        Sounds_UP s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sounds_UP s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
