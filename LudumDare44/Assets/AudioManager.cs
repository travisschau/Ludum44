﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameplayMusic;
    
    // Start is called before the first frame update
    public void PlayMenuMusic()
    {
        musicSource.volume = 0;
        musicSource.DOFade(1, 0.5f);

        musicSource.clip = menuMusic;
        musicSource.Play();
    }
    
    public void PlayGameplayMusic()
    {
        musicSource.DOFade(0, 1f).OnComplete(BeginGameplayMusic);
    }

    private void BeginGameplayMusic()
    {
        musicSource.clip = gameplayMusic;
        musicSource.Play();        
        musicSource.DOFade(1, 1f);
    }

}
