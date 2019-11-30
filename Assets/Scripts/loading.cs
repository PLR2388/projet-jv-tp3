using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    private Image bar;
    public int Speed;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float Diviseur = 1000f / Speed;
        bar.fillAmount = Time.frameCount / Diviseur;
    }
}
