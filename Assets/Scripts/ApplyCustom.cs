using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ApplyCustom : MonoBehaviour
{
    private GameObject controlSettingObject;
    // Start is called before the first frame update
    void Start()
    {
        controlSettingObject = GameObject.FindGameObjectWithTag("ControlSettingObject");
        GameObject pad = controlSettingObject.GetComponent<ControlSettingSc>().customPad;
        if (pad != null)
        {
            gameObject.GetComponent<Renderer>().material.color = pad.GetComponent<Renderer>().material.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
