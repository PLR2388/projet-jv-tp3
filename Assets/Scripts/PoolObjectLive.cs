using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjectLive : MonoBehaviour
{
    public void Disable()
    {
        gameObject.transform.parent.gameObject.GetComponent<AncrePool>().off();
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
