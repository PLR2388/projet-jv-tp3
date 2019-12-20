using System;
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
        switch (pad.name)
        {
            case "affiche":
                if (pad.GetComponent<MeshFilter>().mesh.vertices.Length != 0)
                {
                    float scaleZ = 15.68897f*pad.transform.localScale.z/11341.56f;
                    float repositionnementY = (scaleZ - 15.68897f) * 0.163f / 27.66634f;
                    if (repositionnementY == 0.163f)
                    {
                        repositionnementY -= 0.837f; //Artefact bizarre /!\
                    }
                    gameObject.transform.position=new Vector3(gameObject.transform.position.x,2.437f+repositionnementY,gameObject.transform.position.z);
                    gameObject.transform.localScale = new Vector3(gameObject.transform.lossyScale.x,gameObject.transform.lossyScale.y,scaleZ);
                    int[] t1=new int[pad.GetComponent<MeshFilter>().mesh.triangles.Length/2];
                    int[] t2=new int[pad.GetComponent<MeshFilter>().mesh.triangles.Length/2];
                    for (int i = 0; i < pad.GetComponent<MeshFilter>().mesh.triangles.Length/2; i++)
                    {
                        t1[i] = pad.GetComponent<MeshFilter>().mesh.triangles[i];
             
	        
                    }

                    for (int i = 0; i <  pad.GetComponent<MeshFilter>().mesh.triangles.Length/2; i++)
                    {
                        t2[i] = pad.GetComponent<MeshFilter>().mesh.triangles[i+pad.GetComponent<MeshFilter>().mesh.triangles.Length/2];
            
                    }
            

                    GetComponent<MeshFilter>().mesh.Clear();
                    GetComponent<MeshFilter>().mesh.vertices = pad.GetComponent<MeshFilter>().mesh.vertices;
                    GetComponent<MeshFilter>().mesh.triangles = pad.GetComponent<MeshFilter>().mesh.triangles;
                    gameObject.GetComponent<MeshFilter>().mesh.subMeshCount = 2;
                    GetComponent<MeshFilter>().mesh.SetTriangles(t1,0);
                    GetComponent<MeshFilter>().mesh.SetTriangles(t2,1);
                    GetComponent<MeshRenderer>().materials = pad.GetComponent<MeshRenderer>().materials;
                    GetComponent<MeshFilter>().mesh.RecalculateNormals();
                }
                break;
            case "Pad2":
                GetComponent<MeshFilter>().mesh.Clear();
                GetComponent<MeshFilter>().mesh = pad.GetComponent<MeshFilter>().mesh;
                gameObject.GetComponent<MeshFilter>().mesh.subMeshCount = 2;
                GetComponent<MeshCollider>().sharedMesh = pad.GetComponent<MeshFilter>().mesh;
                GetComponent<MeshRenderer>().materials = pad.GetComponent<MeshRenderer>().materials;
                GetComponent<MeshFilter>().mesh.RecalculateNormals();
                gameObject.transform.rotation=Quaternion.identity;
                float ajustementScale1 = (2*pad.transform.lossyScale.y/1000-0.002f)*0.23f/0.004f;
                gameObject.transform.position=new Vector3(-6.35f,2.5f+ajustementScale1,-11.1f);
                gameObject.transform.localScale=new Vector3(0.002f,2*pad.transform.localScale.y/1000,0.002f);
                break;
            case "Pad3":
                GetComponent<MeshFilter>().mesh.Clear();
                GetComponent<MeshFilter>().mesh = pad.GetComponent<MeshFilter>().mesh;
                gameObject.GetComponent<MeshFilter>().mesh.subMeshCount = 2;
                GetComponent<MeshCollider>().sharedMesh = pad.GetComponent<MeshFilter>().mesh;
                GetComponent<MeshRenderer>().materials = pad.GetComponent<MeshRenderer>().materials;
                GetComponent<MeshFilter>().mesh.RecalculateNormals();
                gameObject.transform.rotation=Quaternion.identity;
                float ajustementScale2 = (pad.transform.lossyScale.y/1000-0.001f)*48;
                gameObject.transform.position=new Vector3(-6.38f,2.422f+ajustementScale2,-12.327f);
                gameObject.transform.localScale=new Vector3(0.001f,pad.transform.lossyScale.y/1000,0.001f);
                
                break;
            
        }
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
