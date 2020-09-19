using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class AnimatorControllerScript : MonoBehaviour
{
    private Animator _animator;
    private MousePositionManager _mousePos;
    private Transform _playerPos;

    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int IsCasting = Animator.StringToHash("isCasting");
    private static readonly int HInput = Animator.StringToHash("hInput");
    private static readonly int VInput = Animator.StringToHash("vInput");
    private static readonly int HDir = Animator.StringToHash("hDir");
    private static readonly int VDir = Animator.StringToHash("vDir");

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindWithTag("Player");
        _animator = GetComponent<Animator>();
        _playerPos = player.transform;
        _mousePos = player.GetComponent<MousePositionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var isCasting = Input.GetButtonDown("Fire1");

        var isMoving = h != 0.0f || v != 0.0f;

        HandlePlayerDirection();
        var direction = (_mousePos.GetMousePos() - _playerPos.position).normalized;

        _animator.SetBool(IsMoving, isMoving);
        _animator.SetBool(IsCasting, isCasting);
        // _animator.SetFloat(HInput, h-direction.x);
        // _animator.SetFloat(VInput, v-direction.z);
        _animator.SetFloat(HInput, h);
        _animator.SetFloat(VInput, v);
    }

    private void HandlePlayerDirection()
    {
        var direction = (_mousePos.GetMousePos() - _playerPos.position).normalized;
        _animator.SetFloat(HDir, direction.x);
        _animator.SetFloat(VDir, direction.z);
        if (Input.GetKeyDown(KeyCode.Space))
            Debug.Log($"Direction: {direction} -- ({direction.x}, {direction.y}, {direction.z})");
    }
}