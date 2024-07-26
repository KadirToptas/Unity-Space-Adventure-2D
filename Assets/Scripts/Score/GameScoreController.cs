using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreController : MonoBehaviour
{
    private int score;
    private int gold;
    
   [SerializeField] private TextMeshProUGUI scoreText; 
   
   [SerializeField] private TextMeshProUGUI goldText; 
    
    
    void Start()
    {
        goldText.text = " X " + gold;
    }

    void Update()
    {
        score = (int)Camera.main.transform.position.y;
        scoreText.text = "Score: " + score;
    }

    public void CollectGold()
    {
        gold++;
        goldText.text = " X " + gold;
    }   
}
