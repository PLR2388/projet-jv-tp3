using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] soundList;
    private static AudioManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound sound in soundList)
        {
            sound.SetAudioSource(gameObject.AddComponent<AudioSource>());
        }
        play("MainTheme");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play(string nameSound)
    {
        foreach (Sound sound in soundList)
        {
            sound.Play(nameSound);
        }
    }

    private void stop(string nameSound)
    {
        foreach (Sound sound in soundList)
        {
            sound.Stop(nameSound);
        }
    }

    public void switchScene(string namePreviousSound, string nameNextSound)
    {
        foreach (Sound sound in soundList)
        {
            sound.Stop(namePreviousSound);
            sound.Play(nameNextSound);
        }
    }

    public float getMusicVolume(string name)
    {
        float? returned = null;
        foreach (Sound sound in soundList)
        {
            returned = sound.getVolume(name);
            if(returned != null)
            {
                break;
            }
        }
        return returned ?? 0f;
    }

    public void setMusicVolume(string name, float volume)
    {
        foreach (Sound sound in soundList)
        {
            sound.setVolume(name, volume);
        }
    }

    public void SpacialPlay(string name, float sense)
    {
        foreach (Sound sound in soundList)
        {
            sound.PlaySpacial(name, sense);
        }
    }

    public void PlaySpacialFooley(string name, float distance, float place)
    {
        foreach (Sound sound in soundList)
        {
            sound.PlaySpacialFooley(name, distance, place);
        }
    }
}
