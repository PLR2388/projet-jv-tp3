using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedIA : MonoBehaviour
{
    private float bordDroit;
    private float bordGauche;
    private float milieu;
    private bool isBump=false;
    private int sens;
    private float pas;
    private float range = 0.1f;
    private int deplacementBump = 10;

    private int latente=0;
    // Start is called before the first frame update
    void Start()
    {
        bordDroit = GetComponent<IACharacteristic>().bordDroit;
        bordGauche = GetComponent<IACharacteristic>().bordGauche;
        milieu = (bordDroit + bordGauche) / 2;
        sens=Random.Range(0, 2);
        pas = GetComponent<IACharacteristic>().pas;
    }

    // Update is called once per frame
    void Update()
    {
        latente++;
        if (latente == 5)
        {
            latente = 0;
            if (isBump)
            {
                transform.position=new Vector3(transform.position.x-deplacementBump*Time.deltaTime,transform.position.y,transform.position.z);
                isBump = false;
            }
            else
            {
                if (sens == 0 && !isBump)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * pas);
                }
                if (sens == 1 && !isBump)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * pas);
                }
        
                if (transform.position.z <= milieu +range && transform.position.z >= milieu - range)
                {
                    transform.position=new Vector3(transform.position.x+deplacementBump*Time.deltaTime,transform.position.y,transform.position.z);
                    isBump = true;
                }
                if (transform.position.z >= bordGauche)
                {
                    sens = 1;
                }
                else if (transform.position.z <= bordDroit)
                {
                    sens = 0;
                }
            }
        }
    }
}
