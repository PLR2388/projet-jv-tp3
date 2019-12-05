using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] soundList;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound sound in soundList)
        {
            sound.SetAudioSource(gameObject.AddComponent<AudioSource>());
        }
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


}
