using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public int NbPoolObject;
    public GameObject PoolObject;
    public float FrequancySpawn;
    private float time = 0;
    private List<GameObject> pool = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i<NbPoolObject;i++)
        {
            GameObject obj = Instantiate(PoolObject, gameObject.transform);
            pool.Add(obj);
        }
    }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 pos = new Vector3(mouse.x, mouse.y-20, gameObject.transform.position.z);
        gameObject.transform.position = pos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time < FrequancySpawn) time += Time.fixedDeltaTime;
        else
        {
            foreach(GameObject obj in pool)
            {
                if(!obj.activeSelf)
                {
                    obj.SetActive(true);
                    time = 0;
                    break;
                }
            }
        }
    }
}
