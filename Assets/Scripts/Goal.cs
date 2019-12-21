using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
     public int scoreToWin = 10;
     private float milieuTerrain = -8.463f;
     public GameObject Puck;

     public GameObject pupet;
    public GameObject[] pupets;

    private GameObject controlSettingObject;
     public GameObject PadIA;
     private int scoreJ1;
     private int scoreJ2;
     public Text Score1;
     public Text Score2;
     public Text NameIA;
     public Text ResultJ1;
     public Text ResultJ2;
     
     /**Permet de réinitialiser la position du palais**/
     private Vector3 positionInit=new Vector3(0,0,20f);
     private Quaternion Quaternion=new Quaternion(-0.7f,0,0,0.7f);
     
    // Start is called before the first frame update
    void Start()
    {
        positionInit = Puck.transform.position;
        scoreJ1 = 0;
        scoreJ2 = 0;
        pupet = GameObject.FindGameObjectWithTag("Puppet");
        pupets = GameObject.FindGameObjectsWithTag("Puppet");
        controlSettingObject = GameObject.FindGameObjectWithTag("ControlSettingObject");
        switch (controlSettingObject.GetComponent<ControlSettingSc>().level)
        {
            case 0:
                NameIA.text = "Personne";
                
                break;
            case 1:
                NameIA.text = "Raoul";
                break;
            case 2:
                NameIA.text = "Richard Nicolas Gregor";
                break;
            case 3:
                NameIA.text = "Cortex";
                break;
            case 4:
                NameIA.text = "Sylvain Durif";
                break;
        }

    }

    private GameObject getPuppet()
    {
        foreach (GameObject puppetfind in pupets)
        {
            if (puppetfind.activeSelf)
            {
                return puppetfind;
            }
        }
        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        /**But du joueur 1**/
        if (other.transform.position.x < milieuTerrain)
        {
            pupet = getPuppet();
            pupet.GetComponent<Animator>().SetTrigger("defeat");

            FindObjectOfType<AudioManager>().play("goal");
            GameObject nouveau=Instantiate(Puck,positionInit,Quaternion);
            Destroy(Puck);
            Puck = nouveau;
            scoreJ1++;
            Score1.text = scoreJ1.ToString();
        }

        /**But du joueur 2 ou de l'IA**/
        if (other.transform.position.x > milieuTerrain)
        {
            pupet = getPuppet();
            pupet.GetComponent<Animator>().SetTrigger("win");
            
            FindObjectOfType<AudioManager>().play("goal");
            GameObject nouveau=Instantiate(Puck,positionInit,Quaternion);
            Destroy(Puck);
            Puck = nouveau;
            scoreJ2++;
            Score2.text = scoreJ2.ToString();
        }

        if (scoreJ1 == scoreToWin)
        {
            Destroy(Puck);
            ResultJ1.text = "Tu as gagne!";
            ResultJ2.text = "Tu as perdu!";
            StartCoroutine(BackMainMenu());
        }
        else if (scoreJ2 == scoreToWin)
        {
            Destroy(Puck);
            ResultJ2.text = "Tu as gagne!";
            ResultJ1.text = "Tu as perdu!";
            StartCoroutine(BackMainMenu());
        }
    }

    IEnumerator BackMainMenu()
    {
        string sameName = SceneManager.GetActiveScene().name;
        if (sameName == "OnePlayer" && ResultJ1.text=="Tu as gagne!") FindObjectOfType<AudioManager>().switchScene("BattleMainTheme", "victory");
        else if (sameName == "OnePlayer" && ResultJ1.text == "Tu as perdu!")
        {
            FindObjectOfType<AudioManager>().switchScene("BattleMainTheme", "defeat");
        }
        yield return new WaitUntil(() => Input.anyKey);
        if (sameName == "OnePlayer" && ResultJ1.text=="Tu as gagne!")
        {
            FindObjectOfType<AudioManager>().switchScene("victory", "MainTheme");
            string path = Application.persistentDataPath + "\\progression.txt";
            switch (NameIA.text)
            {
                case "Personne":
                    File.WriteAllText(path, "1");
                    break;
                case "Raoul":
                    File.WriteAllText(path, "2");
                    break;
                case "Richard Nicolas Gregor":
                    File.WriteAllText(path, "3");
                    break;
                case "Cortex":
                    File.WriteAllText(path, "4");
                    break;
            }
            
        }
        else if (sameName == "OnePlayer" && ResultJ1.text == "Tu as perdu!")
        {
            FindObjectOfType<AudioManager>().switchScene("defeat", "MainTheme");
        }
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MenuScene", LoadSceneMode.Additive);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        //SceneManager.MoveGameObjectToScene(controlSettingObject, SceneManager.GetSceneByName("MenuScene"));
        SceneManager.UnloadSceneAsync(sameName);
    }
}
