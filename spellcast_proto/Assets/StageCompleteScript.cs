using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageCompleteScript : MonoBehaviour
{
    private TextMeshProUGUI _stageComplete;

    private KillCounter _killCounter;
    private AudioManagerScript _audioManager;

    private bool isComplete = false;

    private MenuCanvasScript _menu;
    // Start is called before the first frame update
    void Start()
    {
        _killCounter = GameObject.FindWithTag("KillCounter").GetComponent<KillCounter>();
        _stageComplete = GetComponent<TextMeshProUGUI>();
        _stageComplete.enabled = false;
        _audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManagerScript>();
        _menu = GameObject.FindWithTag("IGMenu").GetComponent<MenuCanvasScript>();
    }

    // Update is called once per frame
    void Update()
    {
        _stageComplete.enabled = (_killCounter.StageComplete && !_menu.isMenuOpen);
        if (!isComplete && _stageComplete.enabled)
            CompleteStage();
    }

    private void CompleteStage()
    {
        isComplete = true;
        _audioManager.PlayOneShot("victory");
    }
}
