using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacteristic : MonoBehaviour
{

    public float pas = 0.5f;
    private GameObject controlSettingObject;
    public float bordDroit = -13.2f;
    public float bordGauche = -12f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] listPuppet = GameObject.FindGameObjectsWithTag("Puppet");
        controlSettingObject = GameObject.FindGameObjectWithTag("ControlSettingObject");
        switch (controlSettingObject.GetComponent<ControlSettingSc>().level)
        {
            case 0:
                gameObject.GetComponent<RandomMoveIA>().enabled = false;
                gameObject.GetComponent<SmartIA>().enabled = false;
                gameObject.GetComponent<ScriptedIA>().enabled = false;
                for (int i = 0; i < listPuppet.Length; i++)
                {
                    if (listPuppet[i].name != "Personne")
                    {
                        listPuppet[i].SetActive(false);
                    }
                }
                break;
            case 1:
                gameObject.GetComponent<RandomMoveIA>().enabled = false;
                gameObject.GetComponent<SmartIA>().enabled = false;
                gameObject.GetComponent<ScriptedIA>().enabled = true;
                for (int i = 0; i < listPuppet.Length; i++)
                {
                    if (listPuppet[i].name != "Raoul")
                    {
                        listPuppet[i].SetActive(false);
                    }
                }

                break;
            case 2:
                gameObject.GetComponent<RandomMoveIA>().enabled = true;
                gameObject.GetComponent<SmartIA>().enabled = false;
                gameObject.GetComponent<ScriptedIA>().enabled = false;
                for (int i = 0; i < listPuppet.Length; i++)
                {
                    if (listPuppet[i].name != "RAND")
                    {
                        listPuppet[i].SetActive(false);
                    }
                }
     
                break;
            case 3: 
                gameObject.GetComponent<RandomMoveIA>().enabled = false;
                gameObject.GetComponent<SmartIA>().enabled = true;
                gameObject.GetComponent<ScriptedIA>().enabled = false;
                for (int i = 0; i < listPuppet.Length; i++)
                {
                    if (listPuppet[i].name != "Cortex")
                    {
                        listPuppet[i].SetActive(false);
                    }
                }
  
                break;
            case 4:
                gameObject.GetComponent<RandomMoveIA>().enabled = false;
                gameObject.GetComponent<SmartIA>().enabled = false;
                gameObject.GetComponent<ScriptedIA>().enabled = false;
                for (int i = 0; i < listPuppet.Length; i++)
                {
                    if (listPuppet[i].name != "Sylvain")
                    {
                        listPuppet[i].SetActive(false);
                    }
                }
     
                break;
        }
    }
}
