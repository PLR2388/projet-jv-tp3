using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BackGroundSetting : MonoBehaviour
{
    public Sprite[] BackgroudPic;
    public SpriteRenderer Backgroud;
    private GameObject controlSettingObject;
    private int AI;

    // Start is called before the first frame update
    void Start()
    {
        controlSettingObject = GameObject.FindGameObjectWithTag("ControlSettingObject");
        AI = controlSettingObject.GetComponent<ControlSettingSc>().level;
        Backgroud.sprite = BackgroudPic[AI];
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
