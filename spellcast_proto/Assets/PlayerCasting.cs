using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public GameObject playerProjector;
    public bool isCasting;
    public bool isAiming;
    private MousePositionManager _positionManager;

    // Start is called before the first frame update
    private void Start()
    {
        isAiming = isCasting = false;
        var player = GameObject.FindWithTag("Player");
        _positionManager = player.GetComponent<MousePositionManager>();
        playerProjector.SetActive(false);
    }

    private void Update()
    {
        ToggleStates();
        UpdateCastingCursorPosition();
    }

    private void ToggleStates()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            isAiming = true;
            isCasting = false;
            playerProjector.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            isAiming = false;
            isCasting = true;
        }
    }

    private void UpdateCastingCursorPosition()
    {
        if (isAiming)
        {
            var pos = _positionManager.GetMousePos();
            playerProjector.transform.position = new Vector3(pos.x, 1, pos.z);
        }
        if (isCasting)
        {
            isCasting = false;
            isAiming = false;
            // Invoke(nameof(DisableProjector), 2f);
        }
    }

    private void DisableProjector()
    {
        playerProjector.SetActive(false);
    }
}