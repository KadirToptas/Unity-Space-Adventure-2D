using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject gameOverPanel;
    
    public GameObject joystick;

    public GameObject jumpButton;

    public GameObject table;

    public GameObject menuButton;
    
    public GameObject slider;

 
    
    void Start()
    {
        gameOverPanel.SetActive(false);
        OpenUI();
    }
    

    public void FinishGame()
    {
        FindObjectOfType<SoundController>().GameOverSound();
        gameOverPanel.SetActive(true);
        FindObjectOfType<GameScoreController>().GameOver();
        FindObjectOfType<PlayerController>().PlayerGameOver();
        FindObjectOfType<CameraController>().CameraGameOver();
        CloseUI(); 
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainScene");
    }

    void OpenUI()
    {
        joystick.SetActive(true);
        jumpButton.SetActive(true);
        table.SetActive(true);
        menuButton.SetActive(true);
        slider.SetActive(true);

    }
    
    void CloseUI()
    {
        joystick.SetActive(false);
        jumpButton.SetActive(false);
        table.SetActive(false);
        menuButton.SetActive(false);
        slider.SetActive(false);
    }
}
