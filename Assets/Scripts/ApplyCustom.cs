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
        if (pad.GetComponent<MeshFilter>().mesh != null)
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
