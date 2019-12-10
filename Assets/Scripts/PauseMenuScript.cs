using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    bool gamePause=false;
    private GameObject controlSettingObject;

    private void Start()
    {
        controlSettingObject = GameObject.FindGameObjectWithTag("ControlSettingObject");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        gamePause = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        gamePause = true;
    }

    public void PauseToMainMenu()
    {
        Time.timeScale = 1;
        FindObjectOfType<AudioManager>().switchScene("BattleMainTheme", "MainTheme");
        StartCoroutine(LoadYourAsyncScene());
    }
    
    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MenuScene");
        while (!asyncLoad.isDone )
        {
            yield return null;
            gameObject.SetActive(false);
        
        }
        SceneManager.UnloadSceneAsync("OnePlayer");
    }
    
}
