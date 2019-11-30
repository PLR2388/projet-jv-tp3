using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartIA : MonoBehaviour
{
    private float bordDroit;
    private float bordGauche;
    private float pas;
    private float rayonPunk=0.14f;
    private float vitesse = 0.5f;
    private float milieuX = -12.70573f;
    private bool goRigth; //Indique si le palais doit être envoyé à droite par rapport à l'IA
    private GameObject Punk;
    private bool enDeplacement = false;
    public GameObject Joueur;
    // Start is called before the first frame update
    void Start()
    {
        bordDroit = GetComponent<IACharacteristic>().bordDroit+0.5f; //Ajustement
        bordGauche = GetComponent<IACharacteristic>().bordGauche-0.2f;
        pas = GetComponent<IACharacteristic>().pas;
    }

    // Update is called once per frame
    void Update()
    {
        Punk=GameObject.FindGameObjectWithTag("Puck");
        Vector3 positionJoueur = Joueur.transform.position;

        if (!enDeplacement)
        {
            if (positionJoueur.z < milieuX) //Le joueur est à gauche, il faut tirer à droite. On se place à droite du Puck pour l'envoyer à gauche
            {
                goRigth = true;
            }
            else
            {
                goRigth = false;
            }
            enDeplacement = true;
        }
        else
        {
            if (goRigth)
            {
                if ((Punk.transform.position.z-rayonPunk) > transform.position.z)
                {
                    transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z+vitesse*Time.deltaTime);
                }
                else if ((Punk.transform.position.z - rayonPunk) < transform.position.z)
                {
                    transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z-vitesse*Time.deltaTime);
                }
                if (transform.position.z > bordGauche)
                {
                    transform.position=new Vector3(transform.position.x,transform.position.y,bordGauche);
                }
                else  if (transform.position.z < bordDroit)
                {
                    transform.position=new Vector3(transform.position.x,transform.position.y,bordDroit+vitesse);
                }
            }
            else
            {
                if (Punk.transform.position.z+rayonPunk < transform.position.z)
                {
                    transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z-vitesse*Time.deltaTime);
                }
                else if (Punk.transform.position.z + rayonPunk > transform.position.z)
                {
                    transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z+vitesse*Time.deltaTime);
                }
                if (transform.position.z < bordDroit)
                {
                    transform.position=new Vector3(transform.position.x,transform.position.y,bordDroit);
                }
                else if (transform.position.z >bordGauche)
                {
                    transform.position=new Vector3(transform.position.x,transform.position.y,bordGauche);
                }
            }

            if (Punk.transform.position.x - rayonPunk < transform.position.x)
            {
                enDeplacement = false;
            }
        }
    }
}
