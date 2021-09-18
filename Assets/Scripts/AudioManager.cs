using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 


public class AudioManager : Singleton<AudioManager>
{
    public Sound[] sounds;
    protected override void Awake()
    {
        base.Awake();
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.loop = s.loop;
        }
        Play("Background");
    }

    public void Play( string name)
    {
        foreach(Sound s in sounds)
        {
            if (s.name == name)
                s.audioSource.Play();
        }
    }

    public void Stop(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
                s.audioSource.Stop();
        }
    }

}

[System.Serializable]
public class Sound
{
    public string name; 
    public AudioClip audioClip;
    public bool loop; 
    [HideInInspector]
    public AudioSource audioSource; 
}
