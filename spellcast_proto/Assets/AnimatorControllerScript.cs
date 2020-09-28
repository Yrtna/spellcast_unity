using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Behaviours;
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

    public GameObject _skillBar;
    private List<AbilityCooldown> _abilities;
    
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindWithTag("Player");
        _animator = GetComponent<Animator>();
        _playerPos = player.transform;
        _mousePos = player.GetComponent<MousePositionManager>();
        _abilities = _skillBar.GetComponents<AbilityCooldown>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        var isMoving = h != 0.0f || v != 0.0f;

        HandlePlayerDirection();
        var direction = (_mousePos.GetMousePos() - _playerPos.position).normalized;

        _animator.SetBool(IsMoving, isMoving);
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
    }

    public void Cast()
    {
        _abilities.ForEach(s=>s.CastSpell());
    }
}