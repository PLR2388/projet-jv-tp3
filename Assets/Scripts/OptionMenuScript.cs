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
        gameObject.SetActive(false);
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


}
