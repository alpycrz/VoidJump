using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip jumping;
    [SerializeField] private AudioClip gold;
    [SerializeField] private AudioClip gameOver;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void JumpSound()
    {
        _audioSource.clip = jumping;
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
