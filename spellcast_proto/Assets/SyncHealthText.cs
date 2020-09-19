using System.Collections;
using System.Collections.Generic;
using Behaviours;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SyncHealthText : MonoBehaviour
{
    private Health _unitHealth;
    public Slider _healthSlider;
    private TextMeshProUGUI _healthText;
    public Transform Bar;
    
    // Start is called before the first frame update
    void Start()
    {
        _unitHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        _healthText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _healthSlider.value = _unitHealth.CurrentHealth;
        _healthText.text = _unitHealth.CurrentHealth.ToString();
    }
}
