using System;
using System.Collections;
using System.Collections.Generic;
using Behaviours;
using UnityEngine;
using UnityEngine.UI;

public class SyncHealthSlider : MonoBehaviour
{
    private Health _unitHealth;
    private Slider _healthSlider;
    public Transform Bar;
    public bool barEnabledByDefault = true;

    // Start is called before the first frame update
    void Start()
    {
        _healthSlider = gameObject.GetComponent<Slider>();
        _unitHealth = GetComponentInParent<Health>();
        _healthSlider.maxValue = _unitHealth.MaxHealth;
        _healthSlider.minValue = 0;
        Bar.gameObject.SetActive(barEnabledByDefault);
    }

    // Update is called once per frame
    void Update()
    {
        _healthSlider.value = _unitHealth.CurrentHealth;
        Bar.gameObject.SetActive(_unitHealth.CurrentHealth < _unitHealth.MaxHealth);
        if (_unitHealth.CurrentHealth <= 0)
            gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}