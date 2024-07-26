using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreController : MonoBehaviour
{
    private int score;
    private int highestScore;   
    private int gold;
    private int highestGold;

    private bool collectScore = true;
    
   [SerializeField] private TextMeshProUGUI scoreText; 
   
   [SerializeField] private TextMeshProUGUI goldText; 
   
   [SerializeField] private TextMeshProUGUI gameOverScoreText; 
   
   [SerializeField] private TextMeshProUGUI gameOverGoldText; 
    
    
    void Start()
    {
        goldText.text = " X " + gold;
    }

    void Update()
    {
        if (collectScore)
        {
            score = (int)Camera.main.transform.position.y;
            scoreText.text = "Score: " + score;
        }
        
    }

    public void CollectGold()
    {
        FindObjectOfType<SoundController>().GoldSound();
        gold++;
        goldText.text = " X " + gold;
    }

    public void GameOver()
    {
        if (SettingsPrefs.ReadEasyValue() == 1)
        {
            highestScore = SettingsPrefs.ReadEasyScoreValue();
            highestGold = SettingsPrefs.ReadEasyGoldValue();
            if (score > highestScore)
            {
                SettingsPrefs.AssignEasyScore(score);
            }

            if (gold > highestGold)
            {
                SettingsPrefs.AssignEasyGold(gold);
            }
        }
        
        
        if (SettingsPrefs.ReadNormalValue() == 1)
        {
            highestScore = SettingsPrefs.ReadNormalScoreValue();
            highestGold = SettingsPrefs.ReadNormalGoldValue();
            if (score > highestScore)
            {
                SettingsPrefs.AssignNormalScore(score);
            }

            if (gold > highestGold)
            {
                SettingsPrefs.AssignNormalGold(gold);
            }
        }
        
        
        
        if (SettingsPrefs.ReadHardValue() == 1)
        {
            highestScore = SettingsPrefs.ReadHardScoreValue();
            highestGold = SettingsPrefs.ReadHardGoldValue();
            if (score > highestScore)
            {
                SettingsPrefs.AssignHardScore(score); 
            }

            if (gold > highestGold)
            {
                SettingsPrefs.AssignHardGold(gold);
            }
        }
        collectScore = false;
        gameOverScoreText.text = "Score: " + score;
        gameOverGoldText.text = " X " + gold;
    }
}
