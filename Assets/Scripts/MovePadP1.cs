using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePadP1 : MonoBehaviour
{
    private GameObject controlSettingObject;
    private KeyCode moveLeft;
    private KeyCode moveRight;
    private KeyCode moveBump;
    private float translationY = 0f;
    private float limiteGauche = -13.401f;
    private float limiteDroite = -11.871f;
    private int tempsBump = 10;

    private bool isPressedRight = false;
    private bool isPressedBump = false;
    private bool isPressedLeft = false;
    private int compteur = 0;

    private bool AxisGamePadPlayer1;
    private delegate bool MoveLeftDBool(KeyCode key);
    MoveLeftDBool MoveLeftDownDelegateMethode;
    private delegate bool MoveRightDBool(KeyCode key);
    MoveRightDBool MoveRightDownDelegateMethode;
    private delegate bool MoveLeftUBool(KeyCode key);
    MoveLeftUBool MoveLeftUpDelegateMethode;
    private delegate bool MoveRightUBool(KeyCode key);
    MoveRightUBool MoveRightUpDelegateMethode;
    private delegate bool MoveBumpBool(KeyCode key);
    MoveBumpBool MoveBumpDelegateMethode;

    // Start is called before the first frame update
    void Start()
    {
        controlSettingObject = GameObject.FindGameObjectWithTag("ControlSettingObject");
        moveLeft = controlSettingObject.GetComponent<ControlSettingSc>().player1Left;
        moveRight = controlSettingObject.GetComponent<ControlSettingSc>().player1Right;
        moveBump = controlSettingObject.GetComponent<ControlSettingSc>().player1Bump;
        AxisGamePadPlayer1 = controlSettingObject.GetComponent<ControlSettingSc>().Player1AxisMode;
        if (!AxisGamePadPlayer1)
        {
            MoveLeftDownDelegateMethode = Input.GetKeyDown;
            MoveRightDownDelegateMethode = Input.GetKeyDown;
            MoveLeftUpDelegateMethode = Input.GetKeyUp;
            MoveRightUpDelegateMethode = Input.GetKeyUp;
            MoveBumpDelegateMethode = Input.GetKeyDown;
        }
        else
        {
            MoveLeftDownDelegateMethode = axisLeftDownBool;
            MoveRightDownDelegateMethode = axisRightDownBool;
            MoveLeftUpDelegateMethode = axisXNeutreBool;
            MoveRightUpDelegateMethode = axisXNeutreBool;
            MoveBumpDelegateMethode = axisBumpBool;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveLeftUpDelegateMethode(moveLeft))
        {
            isPressedLeft = false;
        }
        if (MoveRightUpDelegateMethode(moveRight))
        {
            isPressedRight = false;
        }
        
        if (MoveLeftDownDelegateMethode(moveLeft))
        {
            isPressedLeft = true;
        }
        if (MoveRightDownDelegateMethode(moveRight))
        {
            isPressedRight = true;
        }

        if (MoveBumpDelegateMethode(moveBump))
        {
            isPressedBump = true;
            isPressedRight = false;
            isPressedLeft = false;
        }

        if (isPressedLeft)
        {
            translationY = 1;
        } 
        if (isPressedRight)
        {
            translationY = -1;
        }

        if (!isPressedLeft && !isPressedRight)
        {
            translationY = 0;
        }
    }

    void FixedUpdate()
    {
  
        transform.Translate(0, translationY * Time.fixedDeltaTime, 0);
        if (transform.position.z <= limiteGauche) //Empêcher d'aller trop loin
        {
            transform.position=new Vector3(transform.position.x,transform.position.y,limiteGauche);
        }
        else if(transform.position.z >= limiteDroite)
        {
            transform.position=new Vector3(transform.position.x,transform.position.y,limiteDroite);
        }

        if (isPressedBump)
        {
            compteur++;
            if (compteur == tempsBump/10)
            {
                transform.position=new Vector3(transform.position.x-tempsBump*Time.deltaTime,transform.position.y,transform.position.z);
            }
            else if (compteur == tempsBump)
            {
                transform.position=new Vector3(transform.position.x+tempsBump*Time.deltaTime,transform.position.y,transform.position.z);
                compteur = 0;
                isPressedBump = false;
            }
        }
        
     
    }

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
    }

    private bool axisLeftDownBool(KeyCode k)
    {
        return Input.GetAxis("Horizontal1") < 0;
    }

    private bool axisRightDownBool(KeyCode k)
    {
        return Input.GetAxis("Horizontal1") > 0;
    }

    private bool axisXNeutreBool(KeyCode k)
    {
        return Input.GetAxis("Horizontal1") == 0;
    }

    private bool axisBumpBool(KeyCode k)
    {
        return Input.GetAxis("Vertical1") > 0;
    }


}
