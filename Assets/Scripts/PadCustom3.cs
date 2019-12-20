using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadCustom3 : MonoBehaviour
{
    private static PadCustom3 instance;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
