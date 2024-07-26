using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip jump;
    
    public AudioClip gold;

    public AudioClip gameOver;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void JumpSound()
    {
        _audioSource.clip = jump;
        _audioSource.Play();
    }

    public void GoldSound()
    {
        _audioSource.clip = gold;
        _audioSource.Play();
    }

    public void GameOverSound()
    {
        _audioSource.clip = gameOver;
        _audioSource.Play();
    }
}
