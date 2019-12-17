using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundSetting : MonoBehaviour
{
    public Slider sliderMusic;
    public Slider sliderSFX;
    public Slider sliderFolley;
    private AudioManager audioManager;
    public string BackGroundMusic;
    private string foley = "";
    // Start is called before the first frame update
    void OnEnable()
    {
        audioManager = FindObjectOfType<AudioManager>();
        sliderMusic.value = audioManager.getMusicVolume(BackGroundMusic);
        sliderSFX.value = audioManager.getMusicVolume("puckHit");
        foley = FindObjectOfType<Fooley>().foley;
        sliderFolley.value = audioManager.getMusicVolume(foley);

       
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
        audioManager.setMusicVolume("WallHit", sliderSFX.value);
        
        audioManager.setMusicVolume("transition1",sliderSFX.value);
        audioManager.setMusicVolume("transition2",sliderSFX.value);
    }

    public void Fooley()
    {
        audioManager.setMusicVolume(foley, sliderFolley.value);
    }
}
