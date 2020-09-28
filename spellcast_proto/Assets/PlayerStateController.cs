using System;
using System.Collections;
using System.Collections.Generic;
using Behaviours;
using Data;
using Ludiq.OdinSerializer.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStateController : MonoBehaviour, IKillable
{
    private Health _health;
    private KillCounter _killCounter;
    public int killsToComplete = 30;


    void Start()
    {
        _health = GetComponent<Health>();
        _killCounter = GameObject.FindWithTag("KillCounter")?.GetComponent<KillCounter>();
        if (_killCounter != null)
        {
            _killCounter.killGoal = killsToComplete;
            _killCounter.UpdateText();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Invoke(nameof(Respawn), 5);
    }

    public void Respawn()
    {
        var current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }

    private void Update()
    {
        if (_killCounter && _killCounter.kills >= killsToComplete)
        {
            _killCounter.StageComplete = true;
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("BossDev"))
            {
                Time.timeScale = 0.2f;
                Invoke(nameof(LoadBoss), 2f);
            }
        }
    }

    public void LoadBoss()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("BossDev");
    }
}