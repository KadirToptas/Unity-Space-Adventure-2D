using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class SettingsPrefs
{

    public static string easy = "easy";
    public static string normal = "normal";
    public static string hard = "hard";
    
    public static string easyScore = "easyScore";
    public static string normalScore = "normalScore";
    public static string hardScore = "hardScore";
    
    public static string easyGold = "easyGold";
    public static string normalGold = "normalGold";
    public static string hardGold = "hardGold";


    public static string musicOn = "musicOn";
    public static string musicOff = "musicOff";



    public static void AssignMusicOn(int musicOn)
    {
        PlayerPrefs.SetInt(SettingsPrefs.musicOn, musicOn);
    }
    
    public static int ReadMusicOnValue()
    {
        return PlayerPrefs.GetInt(SettingsPrefs.musicOn);
    }


    public static void AssignEasyScore(int easyScore)
    {
        PlayerPrefs.SetInt(SettingsPrefs.easyScore, easyScore);
    }

    public static int ReadEasyScoreValue()
    {
        return PlayerPrefs.GetInt(SettingsPrefs.easyScore);
    }
    
    public static void AssignNormalScore(int normalScore)
    {
        PlayerPrefs.SetInt(SettingsPrefs.normalScore, normalScore);
    }
    
    public static int ReadNormalScoreValue()
    {
        return PlayerPrefs.GetInt(SettingsPrefs.normalScore);
    }
    
    public static void AssignHardScore(int hardScore)
    {
        PlayerPrefs.SetInt(SettingsPrefs.hardScore, hardScore );
    }
    
    public static int ReadHardScoreValue()
    {
        return PlayerPrefs.GetInt(SettingsPrefs.hardScore);
    }
    
    
    
    
    
    public static void AssignEasyGold(int easyGold)
    {
        PlayerPrefs.SetInt(SettingsPrefs.easyGold, easyGold);
    }

    public static int ReadEasyGoldValue()
    {
        return PlayerPrefs.GetInt(SettingsPrefs.easyGold);
    }
    
    public static void AssignNormalGold(int normalGold)
    {
        PlayerPrefs.SetInt(SettingsPrefs.normalGold, normalGold);
    }
    
    public static int ReadNormalGoldValue()
    {
        return PlayerPrefs.GetInt(SettingsPrefs.normalGold);
    }
    
    public static void AssignHardGold(int hardGold)
    {
        PlayerPrefs.SetInt(SettingsPrefs.hardGold, hardGold );
    }
    
    public static int ReadHardGoldValue()
    {
        return PlayerPrefs.GetInt(SettingsPrefs.hardGold);
    }
    
    
    
    
    
    public static void AssignEasy(int easy)
    {
        PlayerPrefs.SetInt(SettingsPrefs.easy, easy);
    }

    public static int ReadEasyValue()
    {
        return PlayerPrefs.GetInt(SettingsPrefs.easy);
    }
    
    public static void AssignNormal(int normal)
    {
        PlayerPrefs.SetInt(SettingsPrefs.normal, normal);
    }
    
    public static int ReadNormalValue()
    {
        return PlayerPrefs.GetInt(SettingsPrefs.normal);
    }
    
    public static void AssignHard(int hard)
    {
        PlayerPrefs.SetInt(SettingsPrefs.hard, hard );
    }
    
    public static int ReadHardValue()
    {
        return PlayerPrefs.GetInt(SettingsPrefs.hard);
    }

    
    
    
    
    public static bool isSaved()
    {
        if (PlayerPrefs.HasKey(SettingsPrefs.easy) || 
            PlayerPrefs.HasKey(SettingsPrefs.normal) ||
            PlayerPrefs.HasKey(SettingsPrefs.hard))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public static bool isMusicOnSaved()
    {
        if (PlayerPrefs.HasKey(SettingsPrefs.musicOn))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
