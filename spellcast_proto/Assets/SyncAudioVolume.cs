using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncAudioVolume : MonoBehaviour
{
    private AudioSource _audioSource;
    private AudioManagerScript _audioManager;

    public float musicVolume;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        _audioSource.volume = musicVolume * _audioManager.MusicVolume;
    }
}
