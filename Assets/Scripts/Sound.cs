using UnityEngine.Audio;
using UnityEngine;
using System;

[System.Serializable]
public class Sound 
{
    public AudioClip audioClip;
    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    [Range(-1f,1f)]
    public float SpacialSoundLeftRight;
    [Range(0f,1f)]
    public float SpacialSoundCloseFar;
    public bool loop;

    private AudioSource audioSource;

    public void SetAudioSource(AudioSource newAudioSource)
    {
        audioSource = newAudioSource;
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.loop = loop;
        audioSource.panStereo = SpacialSoundLeftRight;
        audioSource.spatialBlend = SpacialSoundCloseFar;
    }

    public void Play(string name)
    {
        if(audioClip.name.Equals(name))
        {
            audioSource.Play();
        }
        
    }

    public void Stop(string name)
    {
        if (audioClip.name.Equals(name))
        {
            audioSource.Stop();
        }
    }

    public float? getVolume(string name)
    {
        if (audioClip.name.Equals(name))
        {
            return audioSource.volume;
        }
        else
        {
            return null;
        }
    }

    internal void setVolume(string name, float volume)
    {
        if (audioClip.name.Equals(name))
        {
            audioSource.volume = volume;
        }
    }

    internal void PlaySpacial(string name, float sense)
    {
        if (audioClip.name.Equals(name))
        {
            audioSource.panStereo = sense;
            audioSource.Play();
        }
    }

    internal void PlaySpacialFooley(string name, float distance, float place)
    {
        if (audioClip.name.Equals(name))
        {
            audioSource.panStereo = place;
            audioSource.spatialBlend = distance;
            audioSource.Play();
        }
    }

    public void SpacialFooley(string name, float distance, float place)
    {
        if (audioClip.name.Equals(name))
        {
            audioSource.panStereo = place;
            audioSource.spatialBlend = distance;
        }
    }

    public void PitchZeroHuit(float PM, string name)
    {
        if (audioClip.name.Equals(name))
        {
            float current;
            audioSource.outputAudioMixerGroup.audioMixer.GetFloat("Pitch", out current);
            current += PM * 0.08f;
            audioSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", current);
        }
    }
    
    public void resetPitch(string name)
    {
        if (audioClip.name.Equals(name))
        {
            audioSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f);
        }
    }

    public void setAudioMixer(string battlemaintheme, AudioMixerGroup audioMixer)
    {
        if (audioClip.name.Equals(battlemaintheme))
        {
            audioSource.outputAudioMixerGroup = audioMixer;
        }
    }
}
