using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicPoolLiving : MonoBehaviour
{
    public void Disable()
    {
        gameObject.transform.parent.gameObject.GetComponent<AncreMagie>().off();
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
