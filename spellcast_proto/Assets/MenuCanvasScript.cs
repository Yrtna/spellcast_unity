using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvasScript : MonoBehaviour
{
    public GameObject Title;
    public GameObject GameMenu;
    public GameObject ControlsMenu;
    public Slider SFXVolumeSlider;
    public Slider MusicVolumeSlider;

    public bool isMenuOpen = false;
    private AudioManagerScript _audioManager;

    public void Resume()
    {
        Time.timeScale = 1f;
        Title.SetActive(false);
        GameMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        isMenuOpen = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Resume();
        Destroy(gameObject);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        isMenuOpen = true;
        Title.SetActive(true);
        GameMenu.SetActive(true);
    }

    public void SetSFXVolume()
    {
        _audioManager.SetSFXVolume(SFXVolumeSlider.value);
    }

    public void SetMusicVolume()
    {
        _audioManager.SetMusicVolume(MusicVolumeSlider.value);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuOpen)
                Resume();
            else
                OpenMenu();
        }
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("IGMenu");
        if (objs.Length > 1)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 1f;
        _audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManagerScript>();
        SFXVolumeSlider.value = _audioManager.SFXVolume;
        MusicVolumeSlider.value = _audioManager.MusicVolume;
    }
}