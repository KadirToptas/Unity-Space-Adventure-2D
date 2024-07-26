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
        
    }
    

    public void ChoosenMode(string level)
    {
        switch (level)
        {
            case "easy":
                easyButton.interactable = false;
                normalButton.interactable = true;
                hardButton.interactable = true;
                break;
            case "normal":
                easyButton.interactable = true;
                normalButton.interactable = false;
                hardButton.interactable = true;
                break;
            case "hard":
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
