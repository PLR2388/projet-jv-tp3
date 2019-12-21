using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovePuckSolo : MonoBehaviour
{
    private float translateX;
    private GameObject controlSettingObject;
    [SerializeField]private Vector3 velocity;
    private bool isSylvain;
    private float positionBumpJ1 = -6.6f;
    private float positionBumpJ2 = -10.6f;
    private float positionLimiteXmin = -10.8f;
    private float positionLimiteXmax = -6.18f;
    private float positionLimiteZmin = -13.41f;
    private float positionLimiteZmax = -11.871f;
    private float milieuTerrain = -8.5f;
    private int vitesseNormal = 15;
    private int vitesseBump = 20;
    private int nombreDecimal = 2;
    public GameObject IA;
    
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
        controlSettingObject = GameObject.FindGameObjectWithTag("ControlSettingObject");
        isSylvain = (controlSettingObject.GetComponent<ControlSettingSc>().level == 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSylvain)
        {
            if (transform.position.z <= positionLimiteZmin ||transform.position.z >= positionLimiteZmax)
            {
                velocity=new Vector3(velocity.x,0,-velocity.z);
                if(transform.position.z <= positionLimiteZmin) FindObjectOfType<AudioManager>().SpacialPlay("WallHit", -1f);
                else if (transform.position.z >= positionLimiteZmax) FindObjectOfType<AudioManager>().SpacialPlay("WallHit", 1f);
            }

            if (transform.position.x >=positionLimiteXmax ||transform.position.x <=positionLimiteXmin)
            {
                velocity=new Vector3(-velocity.x,0,velocity.z);
            }
            transform.position = transform.position + velocity * Time.deltaTime;
        }
        else
        {
            FindObjectOfType<PoolingMagique>().spawnPoolObject(gameObject);
            if (velocity.x<=0 && transform.position.x < milieuTerrain)
            {
                Noeud depart=new Noeud(Math.Round(gameObject.transform.position.z,nombreDecimal),Math.Round(gameObject.transform.position.x,nombreDecimal));
                Noeud arrivee=new Noeud(Math.Round(IA.transform.position.z,nombreDecimal),Math.Round(IA.transform.position.x,nombreDecimal));
                List<Noeud> voisins = depart.getVoisin();
                double min = 9999;
                Noeud minimu=voisins[0];
                for (int i = 1; i < voisins.Count; i++)
                {
                    double tmp = voisins[i].f(arrivee);
                    if (tmp < min)
                    {
                        min = tmp;
                        minimu = voisins[i];
                    }
                }
                if (Time.timeScale != 0)
                {
                    transform.position=new Vector3((float)minimu.Y,transform.position.y,(float)minimu.X);
                }
            }
            else
            {
                if (transform.position.z <= positionLimiteZmin ||transform.position.z >= positionLimiteZmax)
                {
                    velocity=new Vector3(velocity.x,0,-velocity.z);
                    if (transform.position.z <= positionLimiteZmin) FindObjectOfType<AudioManager>().SpacialPlay("WallHit", -1f);
                    else if (transform.position.z >= positionLimiteZmax) FindObjectOfType<AudioManager>().SpacialPlay("WallHit", 1f);
                }

                if (transform.position.x >=positionLimiteXmax ||transform.position.x <=positionLimiteXmin)
                {
                    velocity=new Vector3(-velocity.x,0,velocity.z);
                }
                transform.position = transform.position + velocity * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Vector3 direction = new Vector3(gameObject.transform.position.x - other.transform.position.x,
            0,
            gameObject.transform.position.z - other.transform.position.z);
        if (other.gameObject.name == "Player1" && other.gameObject.transform.position.x<positionBumpJ1)
        {
            FindObjectOfType<AudioManager>().play("puckHit");
            velocity = vitesseBump * direction;
        }
        else if (other.gameObject.name == "Player2" && other.gameObject.transform.position.x>positionBumpJ2)
        {
            FindObjectOfType<AudioManager>().play("puckHit");
            velocity = vitesseBump * direction;
        }
        else if (other.gameObject.name == "Player1" || other.gameObject.name=="Player2")
        {
            FindObjectOfType<AudioManager>().play("puckHit");
            velocity =vitesseNormal*direction;
            
        }
        
    }
}
