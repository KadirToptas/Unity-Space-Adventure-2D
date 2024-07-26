using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public TextMeshProUGUI easyScoreText, easyGoldText, normalScoreText, normalGoldText, hardScoreText, hardGoldText;
    void Start()
    {
        easyScoreText.text = "Score: " + SettingsPrefs.ReadEasyScoreValue();
        easyGoldText.text = " X " + SettingsPrefs.ReadEasyGoldValue();
        
        normalScoreText.text = "Score: " + SettingsPrefs.ReadNormalScoreValue();
        normalGoldText.text = " X " + SettingsPrefs.ReadNormalGoldValue();
        
        hardScoreText.text = "Score: " + SettingsPrefs.ReadHardScoreValue();
        hardGoldText.text = " X " + SettingsPrefs.ReadHardGoldValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
