using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Button easyButton, normalButton, hardButton; 
    // Start is called before the first frame update
    void Start()
    {
        if (SettingsPrefs.ReadEasyValue() == 1)
        {
            easyButton.interactable = false;
            normalButton.interactable = true;
            hardButton.interactable = true;
        }

        if (SettingsPrefs.ReadNormalValue() == 1)
        {
            easyButton.interactable = true;
            normalButton.interactable = false;
            hardButton.interactable = true;
        }

        if (SettingsPrefs.ReadHardValue() == 1)
        {
            easyButton.interactable = true;
            normalButton.interactable = true;
            hardButton.interactable = false;
        }
    }
    

    public void ChoosenMode(string level)
    {
        switch (level)
        {
            case "easy":
                SettingsPrefs.AssignEasy(1);
                SettingsPrefs.AssignNormal(0);
                SettingsPrefs.AssignHard(0);
                easyButton.interactable = false;
                normalButton.interactable = true;
                hardButton.interactable = true;
                break;
            case "normal":
                SettingsPrefs.AssignEasy(0);
                SettingsPrefs.AssignNormal(1);
                SettingsPrefs.AssignHard(0);
                easyButton.interactable = true;
                normalButton.interactable = false;
                hardButton.interactable = true;
                break;
            case "hard":
                SettingsPrefs.AssignEasy(0);
                SettingsPrefs.AssignNormal(0);
                SettingsPrefs.AssignHard(1);
                easyButton.interactable = true;
                normalButton.interactable = true;
                hardButton.interactable = false;
                break;
            default:
                break;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
