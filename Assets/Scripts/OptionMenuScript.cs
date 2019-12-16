using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class OptionMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public Dropdown DropDown1;
    public Dropdown DropDown2;

    public void OptionMenuToMainMenu()
    {
        mainMenu.SetActive(true);
        GetComponent<Animator>().SetTrigger("retour");
        FindObjectOfType<AudioManager>().play("transition1");
        StartCoroutine(deplacement());
    }

    void OnEnable()
    {
        string folder = Application.persistentDataPath;
        string[] allFiles = Directory.GetFiles(folder);
        List<Dropdown.OptionData> list = new List<Dropdown.OptionData>();
        foreach (string file in allFiles)
        {
            string[] name = file.Split('\\');
            list.Add(new Dropdown.OptionData(name[name.Length - 1]));
        }
        DropDown1.AddOptions(list);
        DropDown2.AddOptions(list);
    }
    

    IEnumerator deplacement()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
