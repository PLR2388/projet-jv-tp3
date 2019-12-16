using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ChangeCustom : MonoBehaviour
{
    public GameObject PadCustom;
    public GameObject mainMenu;
    public Color[] Colors =
    {
        Color.black, Color.blue, Color.cyan, Color.gray, Color.green, Color.magenta, Color.red, Color.white,
        Color.yellow
    };

    private int i;
    // Start is called before the first frame update
    void Start()
    {
        PadCustom = GameObject.FindGameObjectWithTag("CustomPad");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CouleurMoins()
    {
        i--;
        if (i < 0)
        {
            i += Colors.Length;
        }

        PadCustom.GetComponent<Renderer>().material.color = Colors[(i % Colors.Length)];
    }
    
    public void CouleurPlus()
    {
        i++;
        print(i%Colors.Length);
        PadCustom.GetComponent<Renderer>().material.color = Colors[(i % Colors.Length)];
    }
    
    public void TailleMoins()
    { //11341.56
        if (PadCustom.transform.localScale.z > 11341.56)
        {
            PadCustom.transform.localScale=new Vector3(PadCustom.transform.localScale.x,PadCustom.transform.localScale.y,PadCustom.transform.localScale.z-1000f);
        }
    }
    
    public void TaillePlus()
    {
        if (PadCustom.transform.localScale.z < 31341.56)
        {
            PadCustom.transform.localScale=new Vector3(PadCustom.transform.localScale.x,PadCustom.transform.localScale.y,PadCustom.transform.localScale.z+1000f);
        }
    }

    public void ValideObject()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Retour()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
    

}
