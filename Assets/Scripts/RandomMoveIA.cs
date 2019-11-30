using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveIA : MonoBehaviour
{
    private float pas;
    private bool isBump = false;
    private int alea = -1;
    private float bordGauche;
    private float bordDroit;
    private int latente = 0;
    private int deplacementBump = 10;
    // Start is called before the first frame update
    void Start()
    {
        pas = gameObject.GetComponent<IACharacteristic>().pas;
        bordGauche = gameObject.GetComponent<IACharacteristic>().bordGauche;
        bordDroit = gameObject.GetComponent<IACharacteristic>().bordDroit;
    }

    // Update is called once per frame
    void Update()
    {
        latente++;
        if (latente == 10)
        {
            latente = 0;
            if (isBump)
            {
                transform.position=new Vector3(transform.position.x-10*Time.deltaTime,transform.position.y,transform.position.z);
                isBump = false;
                alea = Random.Range(0, 3);
            }
            else
            {
                alea = Random.Range(0, 3);
                switch (alea)
                {
                    case 0:
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * pas);
                        if (transform.position.z < bordDroit) //GAUCHE
                        {
                            transform.position=new Vector3(transform.position.x,transform.position.y, transform.position.z + Time.deltaTime * pas);
                        }
                        break;
                    case 1:
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * pas);
                        if (transform.position.z > bordGauche) //DROITE
                        {
                            transform.position=new Vector3(transform.position.x,transform.position.y, transform.position.z - Time.deltaTime * pas);
                        }
                        break;
                    case 2:
                        isBump = true;
                        transform.position=new Vector3(transform.position.x+deplacementBump*Time.deltaTime,transform.position.y,transform.position.z);
                        break;
                }
            }
         
        }
        else if (!isBump)
        {
            switch (alea)
            {
                case 0:
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * pas);
                    if (transform.position.z < bordDroit) //GAUCHE
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * pas);
                    }
                    break;
                case 1:
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * pas);
                    if (transform.position.z > bordGauche) //DROITE
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * pas);
                    }
                    break;
                case 2:
                    isBump = true;
                    transform.position = new Vector3(transform.position.x + deplacementBump * Time.deltaTime, transform.position.y, transform.position.z);
                    break;
            }
        }
    }
}
