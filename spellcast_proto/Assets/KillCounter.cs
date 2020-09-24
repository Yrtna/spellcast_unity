using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public int kills = 0;
    public int killGoal = 0;
    private TextMeshProUGUI _textMesh;
    public bool StageComplete { get; set; } = false;

    void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    public void AddKill()
    {
        kills += 1;
        UpdateText();
    }

    public void UpdateText()
    {
        if (_textMesh != null)
            _textMesh.text = $"Kills: {kills} / {killGoal}";
    }

    public void Reset()
    {
        kills = 0;
        UpdateText();
        StageComplete = false;
    }
}