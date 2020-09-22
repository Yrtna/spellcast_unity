using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    [Range(0.0f, 1.0f)] public float _timeScale;


    private void Start()
    {
        _timeScale = Time.timeScale;
    }

    void Update()
    {
        Time.timeScale = _timeScale;
    }
}
