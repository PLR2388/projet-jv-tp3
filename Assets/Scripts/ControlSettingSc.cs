using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ControlSettingSc : MonoBehaviour
{
    public KeyCode player1Left;
    public KeyCode player1Right;
    public KeyCode player1Bump;
    public KeyCode player2Left;
    public KeyCode player2Right;
    public KeyCode player2Bump;
    public Text[] TextButton;
    public Text InputFeildText;
    public int level; //Permet de savoir quel IA déclencher

    public bool Player1AxisMode = false;
    public bool Player2AxisMode = false;

    // Start is called before the first frame update
    void Start()
    {
        player1Left = KeyCode.A;
        player1Right = KeyCode.D;
        player1Bump = KeyCode.W;
        player2Left = KeyCode.J;
        player2Right = KeyCode.L;
        player2Bump = KeyCode.I;
    }

    public void UpdateControlText(Text label)
    {
        StartCoroutine(UpdateControl(label));
    }

    IEnumerator UpdateControl(Text label)
    {
        label.text = "...Press new key";
        yield return new WaitUntil(() => Input.anyKey);
        label.text = Input.inputString.ToUpper();
        if (label.text.Equals(""))
        {
            for (int i = 0; i < 20; i++)
            {
                if (Input.GetKeyDown("joystick 2 button " + i))
                {
                    label.text = "Joystick2Button" + i;
                }
                else if (Input.GetKeyDown("joystick 1 button " + i))
                {
                    label.text = "Joystick1Button" + i;
                }
            }
        }
    }

    public void PresetControl1(Text label)
    {
        if (label.text.Equals("QWERTY"))
        {
            TextButton[0].text = "A";
            TextButton[1].text = "D";
            TextButton[2].text = "W";
            Player1AxisMode = false;
        }
        else if (label.text.Equals("AZERTY"))
        {
            TextButton[0].text = "Q";
            TextButton[1].text = "D";
            TextButton[2].text = "Z";
            Player1AxisMode = false;
        }
        else if (label.text.Equals("IJL"))
        {
            TextButton[0].text = "J";
            TextButton[1].text = "L";
            TextButton[2].text = "I";
            Player1AxisMode = false;
        }
        else if (label.text.Equals("GAMEPAD"))
        {
            TextButton[0].text = "JoystickButton2";
            TextButton[1].text = "JoystickButton1";
            TextButton[2].text = "JoystickButton3";
            Player1AxisMode = false;
        }
        else if (label.text.Equals("AxisGamePad1"))
        {
            Player1AxisMode = true;
        }
        else
        {
            string path = Application.persistentDataPath + "\\" + label.text;
            string[] lines = File.ReadAllLines(path);
            TextButton[0].text = lines[0];
            TextButton[1].text = lines[1];
            TextButton[2].text = lines[2];
            Player1AxisMode = false;
        }
    }

    public void PresetControl2(Text label)
    {
        if (label.text.Equals("QWERTY"))
        {
            TextButton[3].text = "A";
            TextButton[4].text = "D";
            TextButton[5].text = "W";
            Player2AxisMode = false;
        }
        else if (label.text.Equals("AZERTY"))
        {
            TextButton[3].text = "Q";
            TextButton[4].text = "D";
            TextButton[5].text = "Z";
            Player2AxisMode = false;
        }
        else if (label.text.Equals("IJL"))
        {
            TextButton[3].text = "J";
            TextButton[4].text = "L";
            TextButton[5].text = "I";
            Player2AxisMode = false;
        }
        else if (label.text.Equals("GAMEPAD"))
        {
            TextButton[3].text = "JoystickButton2";
            TextButton[4].text = "JoystickButton1";
            TextButton[5].text = "JoystickButton3";
            Player2AxisMode = false;
        }
        else if (label.text.Equals("AxisGamePad2"))
        {
            Player2AxisMode = true;
        }
        else
        {
            string path = Application.persistentDataPath + "\\" + label.text;
            string[] lines = File.ReadAllLines(path);
            TextButton[3].text = lines[0];
            TextButton[4].text = lines[1];
            TextButton[5].text = lines[2];
            Player2AxisMode = false;
        }
    }

    public void UpdateAllKeyCode()
    {
        if (Player1AxisMode == false) UpdatePlayer1Control(); 
        if (Player2AxisMode == false) UpdatePlayer2Control();
    }

    private void UpdatePlayer1Control()
    {
        //https://answers.unity.com/questions/653106/string-to-keycode.html
        player1Left = (KeyCode)System.Enum.Parse(typeof(KeyCode), TextButton[0].text);
        player1Right = (KeyCode)System.Enum.Parse(typeof(KeyCode), TextButton[1].text);
        player1Bump = (KeyCode)System.Enum.Parse(typeof(KeyCode), TextButton[2].text);
    }

    private void UpdatePlayer2Control()
    {
        //https://answers.unity.com/questions/653106/string-to-keycode.html
        player2Left = (KeyCode)System.Enum.Parse(typeof(KeyCode), TextButton[3].text);
        player2Right = (KeyCode)System.Enum.Parse(typeof(KeyCode), TextButton[4].text);
        player2Bump = (KeyCode)System.Enum.Parse(typeof(KeyCode), TextButton[5].text);
    }

    public void ExportControl(int i)
    {
        string[] lines = { TextButton[0 + i].text, TextButton[1 + i].text, TextButton[2 + i].text };
        string path = Application.persistentDataPath + "\\" + InputFeildText.text;
        File.WriteAllLines(path, lines);
    }



}
