using System;
using System.Collections;
using System.Collections.Generic;
using Behaviours;
using UnityEngine;

public class ApplyEffect_Potion : MonoBehaviour
{
    private Health _playerHealth;

    public int HealQuantity=10;
    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerHealth.Heal(HealQuantity);
            Destroy(gameObject);
        }
    }
}
