using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundSetting : MonoBehaviour
{
    public Slider sliderMusic;
    public Slider sliderSFX;
    private AudioManager audioManager;
    public string BackGroundMusic;
    // Start is called before the first frame update
    void OnEnable()
    {
        audioManager = FindObjectOfType<AudioManager>();
        sliderMusic.value = audioManager.getMusicVolume(BackGroundMusic);
        sliderSFX.value = audioManager.getMusicVolume("puckHit");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicUpdate()
    {
        audioManager.setMusicVolume(BackGroundMusic, sliderMusic.value);
    }

    public void SFXUpdate()
    {
        audioManager.setMusicVolume("puckHit", sliderSFX.value);
        audioManager.setMusicVolume("goal", sliderSFX.value);
    }
}
