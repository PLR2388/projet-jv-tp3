using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PadCustom : MonoBehaviour
{
    private static PadCustom instance;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = GameObject.Find(instance.name);
        if (gameObject != instance)
        {
            Destroy(gameObject);
        }
        if(instance == null)
        {
            instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
