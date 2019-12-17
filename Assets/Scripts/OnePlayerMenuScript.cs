using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnePlayerMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controlSettingObject;

    public GameObject IA2;
    public GameObject IA3;
    public GameObject IA4;
    public GameObject IA5;
    private bool animationRotation=false;
    private float time=0f;
    public GameObject ancreOnePlayer;
    
    public void PlayerOneMenuToMainMenu()
    {
        mainMenu.SetActive(true);
        //gameObject.SetActive(false);
        FindObjectOfType<AudioManager>().play("transition2");
        animationRotation = true;
    }

    public void PlayerOneMenuToPersonne()
    {
        StartCoroutine(LoadPersonne());
    }
    
    void FixedUpdate()
    {
        if (animationRotation)
        {
            
            float value = 90 * Time.fixedDeltaTime;
            ancreOnePlayer.transform.Rotate(0,0,value);
            if (ancreOnePlayer.transform.rotation.z > 0.895f)
            {
                animationRotation = false;
                gameObject.SetActive(false);
            }
        }
    }
    
    IEnumerator LoadPersonne()
    {
        controlSettingObject.GetComponent<ControlSettingSc>().level = 0;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("OnePlayer", LoadSceneMode.Additive);
        while (!asyncLoad.isDone )
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(controlSettingObject, SceneManager.GetSceneByName("OnePlayer"));
        FindObjectOfType<AudioManager>().switchScene("MainTheme", "BattleMainTheme");
        SceneManager.UnloadSceneAsync("MenuScene");
    }
    
    public void PlayerOneMenuToRaoul()
    {
        StartCoroutine(LoadRaoul());
    }
    IEnumerator LoadRaoul()
    {
        controlSettingObject.GetComponent<ControlSettingSc>().level = 1;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("OnePlayer", LoadSceneMode.Additive);
        while (!asyncLoad.isDone )
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(controlSettingObject, SceneManager.GetSceneByName("OnePlayer"));
        FindObjectOfType<AudioManager>().switchScene("MainTheme", "BattleMainTheme");
        SceneManager.UnloadSceneAsync("MenuScene");
    }
    
    public void PlayerOneMenuToRandom()
    {
        StartCoroutine(LoadRandom());
    }
    IEnumerator LoadRandom()
    {
        controlSettingObject.GetComponent<ControlSettingSc>().level = 2;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("OnePlayer", LoadSceneMode.Additive);
        while (!asyncLoad.isDone )
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(controlSettingObject, SceneManager.GetSceneByName("OnePlayer"));
        FindObjectOfType<AudioManager>().switchScene("MainTheme", "BattleMainTheme");
        SceneManager.UnloadSceneAsync("MenuScene");
    }
    public void PlayerOneMenuToCortex()
    {
        StartCoroutine(LoadCortex());
    }
    IEnumerator LoadCortex()
    {
        controlSettingObject.GetComponent<ControlSettingSc>().level = 3;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("OnePlayer", LoadSceneMode.Additive);
        while (!asyncLoad.isDone )
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(controlSettingObject, SceneManager.GetSceneByName("OnePlayer"));
        FindObjectOfType<AudioManager>().switchScene("MainTheme", "BattleMainTheme");
        SceneManager.UnloadSceneAsync("MenuScene");
    }
    public void PlayerOneMenuToSylvain()
    {
        StartCoroutine(LoadSylvain());
    }
    IEnumerator LoadSylvain()
    {
        controlSettingObject.GetComponent<ControlSettingSc>().level = 4;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("OnePlayer", LoadSceneMode.Additive);
        while (!asyncLoad.isDone )
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(controlSettingObject, SceneManager.GetSceneByName("OnePlayer"));
        FindObjectOfType<AudioManager>().switchScene("MainTheme", "BattleMainTheme");
        SceneManager.UnloadSceneAsync("MenuScene");
    }

    public void OnEnable()
    {
        string folder = Application.persistentDataPath;
        string[] allFiles = Directory.GetFiles(folder);
        if (allFiles.Contains(Application.persistentDataPath+"\\progression.txt")) //Si le fichier progression.txt existe, on cherche le nombre à l'intérieur pour connaître les niveaux débloqués
        {
            string path = Application.persistentDataPath + "\\progression.txt";
            string lines = File.ReadAllText(path);
            switch (lines)
            {
                case "1":
                    IA2.SetActive(true);
                    break;
                case "2":
                    IA2.SetActive(true);
                    IA3.SetActive(true);
                    break;
                case "3":
                    IA2.SetActive(true);
                    IA3.SetActive(true);
                    IA4.SetActive(true);
                    break;
                case "4":
                    IA2.SetActive(true);
                    IA3.SetActive(true);
                    IA4.SetActive(true);
                    IA5.SetActive(true);
                    break;
            }
        }
    }

    public void Unlock()
    {
        IA2.SetActive(true);
        IA3.SetActive(true);
        IA4.SetActive(true);
        IA5.SetActive(true);
    }
}
