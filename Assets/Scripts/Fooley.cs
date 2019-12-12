using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fooley : MonoBehaviour
{
    private AudioManager audioManager;
    private int time;
    public int frequancy = 150;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time == frequancy)
        {
            float distance = Random.Range(0f, 1f);
            float place = Random.Range(-1f, 1f);
            audioManager.PlaySpacialFooley("air", distance, place);
            time = 0;
        }
        else
        {
            time++;
        }
    }
}
