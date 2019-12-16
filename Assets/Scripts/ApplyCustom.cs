using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ApplyCustom : MonoBehaviour
{
    private GameObject controlSettingObject;
    // Start is called before the first frame update
    void Start()
    {
        GameObject pad = GameObject.FindGameObjectWithTag("CustomPad");
        if (pad != null)
        {
            float scaleZ = 15.68897f*pad.transform.localScale.z/11341.56f;
            float repositionnementY = (scaleZ - 15.68897f) * 0.163f / 27.66634f;
            print("scaleZ="+scaleZ);
            print("repositionneY="+repositionnementY);
            print(gameObject.transform.position.y+repositionnementY);
            if (repositionnementY == 0.163f)
            {
                repositionnementY -= 0.837f; //Artefact bizarre /!\
            }
            gameObject.GetComponent<Renderer>().material.color = pad.GetComponent<Renderer>().material.color;
            gameObject.transform.position=new Vector3(gameObject.transform.position.x,2.437f+repositionnementY,gameObject.transform.position.z);
            gameObject.transform.localScale = new Vector3(gameObject.transform.lossyScale.x,gameObject.transform.lossyScale.y,scaleZ);
            
            GetComponent<MeshFilter>().sharedMesh = pad.GetComponent<MeshFilter>().sharedMesh;
         
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
