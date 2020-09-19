using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ScrollingTextScript : MonoBehaviour
{
    public float scrollingSpeed;
    public float lifespan;

    private void Start()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * (scrollingSpeed * Time.deltaTime));
    }
}