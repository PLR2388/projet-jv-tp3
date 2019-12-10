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
        gameObject.SetActive(false);
    }

    public void MainMenuToOnePlayer()
    {
        personnalisationMenu.SetActive(false);
        playerOneMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void MainMenuToPersonnalisation()
    {
        playerOneMenu.SetActive(false);
        personnalisationMenu.SetActive(true);
        gameObject.SetActive(false);
        
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
