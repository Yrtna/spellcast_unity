using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public int kills = 0;

    private TextMeshProUGUI _textMesh;

    void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void AddKill()
    {
        kills += 1;
        UpdateText();
    }

    private void UpdateText()
    {
        _textMesh.text = $"Kills: {kills}";
    }

    public void Reset()
    {
        kills = 0;
        UpdateText();
    }
}