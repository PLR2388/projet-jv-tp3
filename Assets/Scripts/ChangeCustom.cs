using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCustom : MonoBehaviour
{
    public GameObject PadCustom;
    public GameObject mainMenu;
    public GameObject ConvDescript;
    public Color[] Colors =
    {
        Color.black, Color.blue, Color.cyan, Color.gray, Color.green, Color.magenta, Color.red, Color.white,
        Color.yellow
    };

    private int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickGauche()
    {
        i--;
        if (i < 0)
        {
            i += Colors.Length;
        }

        PadCustom.GetComponent<Renderer>().material.color = Colors[(i % Colors.Length)];
    }
    
    public void clickDroit()
    {
        i++;
        print(i%Colors.Length);
        PadCustom.GetComponent<Renderer>().material.color = Colors[(i % Colors.Length)];
    }

    public void ValideObject()
    {
        ConvDescript.GetComponent<ControlSettingSc>().customPad = PadCustom;
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
