using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public AudioClip audioClip;
    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    public bool loop;

    private AudioSource audioSource;

    public void SetAudioSource(AudioSource newAudioSource)
    {
        audioSource = newAudioSource;
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.loop = loop;
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

}
