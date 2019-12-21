using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncreMagie : MonoBehaviour
{
    private GameObject table;
    private Vector3 position;

    public void setTable(GameObject gameObject)
    {
        table = gameObject;
    }
    
    void OnEnable()
    {
        position = gameObject.transform.parent.position;
        gameObject.transform.SetParent(null);
        gameObject.transform.position = position;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void off()
    {
        gameObject.transform.SetParent(FindObjectOfType<PoolingMagique>().transform);
        gameObject.transform.position = Vector3.zero;
    }
}
