using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    [SerializeField] private Sprite[] musicIkons;

    [SerializeField]  private Button musicButton;

    
    
    
    void Start()
    {
        if (SettingsPrefs.isSaved() == false)
        {
            SettingsPrefs.AssignEasy(1);
        }

        if (SettingsPrefs.isMusicOnSaved() == false)
        {
            SettingsPrefs.AssignMusicOn(1);
        }
        CheckMusicSettings();
    }

    
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
        if (SettingsPrefs.ReadMusicOnValue()==1)
        {
            SettingsPrefs.AssignMusicOn(0); 
            MusicController.instance.PlayMusic(false);
            musicButton.image.sprite = musicIkons[0];
        }
        else
        {
            SettingsPrefs.AssignMusicOn(1); 
            MusicController.instance.PlayMusic(true);
            musicButton.image.sprite = musicIkons[1];
        }
    }


    void CheckMusicSettings()
    {
        if (SettingsPrefs.ReadMusicOnValue() == 1)
        {
            musicButton.image.sprite = musicIkons[1];
            MusicController.instance.PlayMusic(true);

        }
        else
        {
            musicButton.image.sprite = musicIkons[0];
            MusicController.instance.PlayMusic(false);

        }
    }
    
}
