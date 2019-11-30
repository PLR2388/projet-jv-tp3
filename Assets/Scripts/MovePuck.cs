using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovePuck : MonoBehaviour
{
    private float translateX;
    private Vector3 velocity;
    private bool isSylvain;
    private float positionBumpJ1 = -6.6f;
    private float positionBumpJ2 = -10.6f;
    private float positionLimiteXmin = -10.8f;
    private float positionLimiteXmax = -6.18f;
    private float positionLimiteZmin = -13.414f;
    private float positionLimiteZmax = -11.871f;
    private int vitesseNormal = 15;
    private int vitesseBump = 20;
   
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0f, 1f) < 0.5f)
        {
            velocity=new Vector3(1,0,0);
   
        }
        else
        {
            velocity=new Vector3(-1,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= positionLimiteZmin ||transform.position.z >= positionLimiteZmax)
        {
            velocity=new Vector3(velocity.x,0,-velocity.z);
        }

        if (transform.position.x >=positionLimiteXmax ||transform.position.x <=positionLimiteXmin)
        {
            velocity=new Vector3(-velocity.x,0,velocity.z);
        }
        transform.position = transform.position + velocity * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
       Vector3 direction = new Vector3(gameObject.transform.position.x - other.transform.position.x,
            0,
            gameObject.transform.position.z - other.transform.position.z);
       if (other.gameObject.name == "Player1" && other.gameObject.transform.position.x<positionBumpJ1)
        {
            velocity = vitesseBump * direction;
        }
        else if (other.gameObject.name == "Player2" && other.gameObject.transform.position.x>positionBumpJ2)
        {
            velocity = vitesseBump * direction;
        }
        else if (other.gameObject.name == "Player1" || other.gameObject.name=="Player2")
        {
            velocity =vitesseNormal*direction;
        }
        
    }
}
