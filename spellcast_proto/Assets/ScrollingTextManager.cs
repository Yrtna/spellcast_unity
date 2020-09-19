using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScrollingTextManager : MonoBehaviour
{
    public GameObject scrollingText;

    public void NewDamage(int qty, Transform pos)
    {
        var tmp = Instantiate(scrollingText, transform);
        tmp.transform.position = pos.position;
        var text = tmp.GetComponentInChildren<TextMeshProUGUI>();
        text.text = $"-{qty}";
        text.color = Color.red;
    }

    public void NewHeal(int qty, Transform pos)
    {
        var tmp = Instantiate(scrollingText, transform);
        tmp.transform.position = pos.position;
        var text = tmp.GetComponentInChildren<TextMeshProUGUI>();
        text.text = $"+{qty}";
        text.color = Color.green;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NewDamage(420, GameObject.FindWithTag("Player").transform);
        }
    }
}