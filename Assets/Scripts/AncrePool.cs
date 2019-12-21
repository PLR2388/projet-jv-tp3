using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncrePool : MonoBehaviour
{
    void OnEnable()
    {
        gameObject.transform.SetParent(gameObject.transform.parent.parent);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void off()
    {
        gameObject.transform.SetParent(FindObjectOfType<Pooling>().transform);
        gameObject.transform.position = gameObject.transform.parent.position;
    }
}
