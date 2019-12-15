using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fooley : MonoBehaviour
{
    private AudioManager audioManager;
    private int time;
    public int frequancy = 150;
    private GameObject controlSettingObject;
    private int AI;
    public string foley = null;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        controlSettingObject = GameObject.FindGameObjectWithTag("ControlSettingObject");
        AI = controlSettingObject.GetComponent<ControlSettingSc>().level;
        switch(AI)
        {
            case 0:
                foley = "bugWindows";
                break;
            case 1:
                foley = "air";
                break;
            case 2:
                foley = "whisper";
                audioManager.PlaySpacialFooley(foley, 0, 0);
                break;
            case 3:
                foley = "narf";
                break;
            case 4:
                foley = "space";
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time == frequancy)
        {
            
            float distance = Random.Range(0f, 1f);
            float place = Random.Range(-1f, 1f);
            if (AI != 2) audioManager.PlaySpacialFooley(foley, distance, place);
            else audioManager.spacialMove(foley, distance, place);
            time = 0;
        }
        else
        {
            time++;
        }
    }
}
