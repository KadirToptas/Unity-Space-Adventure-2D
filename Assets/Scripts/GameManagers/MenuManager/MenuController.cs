using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    [SerializeField] private Sprite[] musicIkons;

    [SerializeField]  private Button musicButton;

    private bool musicIsOn = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ShowHighScores()
    {
        SceneManager.LoadScene("ScoreScene");
    }

    public void ShowSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void Music()
    {
        if (musicIsOn)
        {
            musicIsOn = false;
            musicButton.image.sprite = musicIkons[0];
        }
        else
        {
            musicIsOn = true;
            musicButton.image.sprite = musicIkons[1];
        }
    }
    
}
