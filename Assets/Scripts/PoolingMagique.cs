using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingMagique : MonoBehaviour
{
    public int NbPoolObject;
    public GameObject PoolObject;
    private List<GameObject> pool = new List<GameObject>();
    public GameObject referenceSpwan;
    public float z = 0;

    public GameObject table;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NbPoolObject; i++)
        {
            GameObject obj = Instantiate(PoolObject, gameObject.transform);
            obj.GetComponent<AncreMagie>().setTable(table);
            pool.Add(obj);
        }
    }

    void Update()
    {
        referenceSpwan = GameObject.FindGameObjectWithTag("Puck");
        gameObject.transform.position = new Vector3(referenceSpwan.transform.position.x,z, referenceSpwan.transform.position.z);
    }

    public void spawnPoolObject(GameObject reference)
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeSelf)
            {
                float x = Random.Range(-2f, 2f);
                float y = Random.Range(-2f, 2f);
                obj.SetActive(true);
                //obj.transform.position = new Vector3(x, z, y);
                break;
            }
        }
    }
}


