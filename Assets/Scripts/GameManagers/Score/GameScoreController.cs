using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreController : MonoBehaviour
{
    private int score;
    private int gold;

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
        gold++;
        goldText.text = " X " + gold;
    }

    public void GameOver()
    {
        collectScore = false;
        gameOverScoreText.text = "Score: " + score;
        gameOverGoldText.text = " X " + gold;
    }
}
