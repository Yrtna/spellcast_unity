using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageCompleteScript : MonoBehaviour
{
    private TextMeshProUGUI _stageComplete;

    private KillCounter _killCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        _killCounter = GameObject.FindWithTag("KillCounter").GetComponent<KillCounter>();
        _stageComplete = GetComponent<TextMeshProUGUI>();
        _stageComplete.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _stageComplete.enabled = _killCounter.StageComplete;
    }
}
