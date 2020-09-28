using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;

    private AudioManagerScript _audioManager;

    private void Start()
    {
        _audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManagerScript>();
        sfxVolumeSlider.value = _audioManager.SFXVolume;
        musicVolumeSlider.value = _audioManager.MusicVolume;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume()
    {
        _audioManager.SetSFXVolume(sfxVolumeSlider.value);
        _audioManager.SetMusicVolume(musicVolumeSlider.value);
    }
}