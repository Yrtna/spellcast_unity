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


    void Start()
    {
        _health = GetComponent<Health>();
        _killCounter = GameObject.FindWithTag("KillCounter").GetComponent<KillCounter>();
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Invoke(nameof(Respawn), 5);
    }

    public void Respawn()
    {
        // var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // enemies.ForEach(s => Destroy(s));
        // var loot = GameObject.FindGameObjectsWithTag("Loot");
        // loot.ForEach(s => Destroy(s));
        //
        // _killCounter.Reset();
        // _health.Heal(_health.MaxHealth);
        // gameObject.SetActive(true);
        // gameObject.transform.position = Vector3.zero;
        SceneManager.LoadScene("Scenes/Arena");
    }
}