using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class AudioManagerScript : MonoBehaviour
{
    public SerializedDictionary<string, GameSfx> AudioClips;
    public float SFXVolume = 0.5f;
    public float MusicVolume = 0.5f;


    private AudioSource _randomAudioSource;
    private AudioSource[] _pitchedAudioSources;

    private void Start()
    {
        _pitchedAudioSources = GetComponentsInChildren<AudioSource>();
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);
        if (objs.Length > 1)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void PlayOneShot(string clipName, float clipVolume = 1f)
    {
        _randomAudioSource = _pitchedAudioSources[Random.Range(0, _pitchedAudioSources.Length - 1)];
        clipName = clipName.ToLower();
        if (AudioClips[clipName] != null)
            _randomAudioSource.PlayOneShot(AudioClips[clipName].clip, AudioClips[clipName].volume * SFXVolume);
    }

    public void SetSFXVolume(float amount)
    {
        SFXVolume = amount;
    }

    public void SetMusicVolume(float amount)
    {
        MusicVolume = amount;
    }
}

[Serializable]
public class GameSfx
{
    public AudioClip clip;
    public float volume;
}