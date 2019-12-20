using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject playerOneMenu;
    public GameObject controlSettingObject;
    public GameObject personnalisationMenu;
    private bool animationRotation=false;
    private float time=0f;
    public GameObject ancreOnePlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        optionMenu.SetActive(false);
        controlSettingObject = GameObject.FindGameObjectWithTag("ControlSettingObject");
    }

    public void mainMenuToOption()
    {
        personnalisationMenu.SetActive(false);
        optionMenu.SetActive(true);
        FindObjectOfType<AudioManager>().play("transition1");
    }

    public void MainMenuToOnePlayer()
    {
        personnalisationMenu.SetActive(false);
        playerOneMenu.SetActive(true);
        animationRotation = true;
        FindObjectOfType<AudioManager>().play("transition2");
     //   gameObject.SetActive(false);
    }

    public void MainMenuToPersonnalisation()
    {
        playerOneMenu.SetActive(false);
        personnalisationMenu.SetActive(true);
        gameObject.SetActive(false);
        
    }

     void FixedUpdate()
    {
        if (animationRotation)
        {
            time += Time.fixedDeltaTime;
            double alpha = 6 * Math.Pow(time, 5) - 15 * Math.Pow(time, 4) + 10 * Math.Pow(time, 3);
            float position = (float)(1 - alpha) * 90;
           // print(position);
            float actualRotation=ancreOnePlayer.transform.rotation.z*100;
            float rotation = position-actualRotation;
            ancreOnePlayer.transform.Rotate(0,0,rotation);
            //print(ancreOnePlayer.transform.rotation.z);
            if (ancreOnePlayer.transform.rotation.z < 0)
            {
                ancreOnePlayer.transform.rotation=Quaternion.identity;
                animationRotation = false;
                time = 0;
            }
        }
    }

    public void MainMenuToTwoPlayer()
    {
        SceneManager.LoadScene("Loading", LoadSceneMode.Additive);
        FindObjectOfType<AudioManager>().switchScene("MainTheme", "BattleMainTheme");
        StartCoroutine(LoadYourAsyncScene());
    }
    
    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("TwoPlayer", LoadSceneMode.Additive);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone )
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(controlSettingObject, SceneManager.GetSceneByName("TwoPlayer"));
        SceneManager.UnloadSceneAsync("Loading");
        SceneManager.UnloadSceneAsync("MenuScene");
    }

    public void quitGame()
    {
        Application.Quit();
    }
    
    
}
