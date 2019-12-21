using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] soundList;
    private static AudioManager instance;

    public AudioMixerGroup audioMixer;
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
            setAudioMixer("BattleMainTheme", sound);
        }
        play("MainTheme");
    }

    private void setAudioMixer(string battlemaintheme, Sound sound1)
    {
        sound1.setAudioMixer(battlemaintheme, audioMixer);
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
        float volume = 0f;
        foreach (Sound sound in soundList)
        {
            volume = sound.getVolume(namePreviousSound) ?? 0f;
            if (volume != 0f)
            {
                StartCoroutine(musicLow(namePreviousSound, volume));
                break;
            }
        }
        StartCoroutine(musicHigh(nameNextSound, volume));
    }

    IEnumerator musicLow(string namePreviousSound, float volume)
    {
        float vol = volume / 4;
        setMusicVolume(namePreviousSound, volume - vol);
        yield return new WaitForSeconds(1f);
        setMusicVolume(namePreviousSound, volume - 2 * vol);
        yield return new WaitForSeconds(1f);
        setMusicVolume(namePreviousSound, volume - 3 * vol);
        yield return new WaitForSeconds(1f);
        stop(namePreviousSound);

    }

    IEnumerator musicHigh(string nameNextSound, float volume)
    {
        play(nameNextSound);
        float vol = volume / 4;
        setMusicVolume(nameNextSound, vol);
        yield return new WaitForSeconds(1f);
        setMusicVolume(nameNextSound, 2 * vol);
        yield return new WaitForSeconds(1f);
        setMusicVolume(nameNextSound, 3 * vol);
        yield return new WaitForSeconds(1f);
        setMusicVolume(nameNextSound, volume);
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

    public void spacialMove(string name, float distance, float place)
    {
        foreach (Sound sound in soundList)
        {
            sound.SpacialFooley(name, distance, place);
        }
    }
    
    public void pitchChange(string name, float PM)
    {
        foreach (Sound sound in soundList)
        {
            sound.PitchZeroHuit(PM, name);
        }
    }
    
    public void resetPitch(string name)
    {
        foreach (Sound sound in soundList)
        {
            sound.resetPitch(name);
        }
    }
}
