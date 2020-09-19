using System.Collections;
using System.Collections.Generic;
using Data;
using Microsoft.Win32;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IKillable
{
    private Transform _player;
    private NavMeshAgent _navMeshAgent;
    private EnemyAbility _ability;
    public int rotationSpeed = 5;
    private KillCounter _killCounter;
    public GameObject DeathPoof;
    private DropLoot _loot;
    public float FollowDistance = 5f;
    private Animator _animator;

    public bool isPaused;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int IsAttacking = Animator.StringToHash("isAttacking");

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _ability = gameObject.GetComponentInChildren<EnemyAbility>();
        isPaused = false;
        _killCounter = GameObject.FindWithTag("KillCounter").GetComponent<KillCounter>();
        _loot = GetComponent<DropLoot>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player is null)
            return;
        FollowPlayer();
        if (PlayerInLos())
            FaceTarget();

        if (PlayerInFront())
        {
            var cast = _ability.Cast();
            if (cast && !_animator.GetBool(IsAttacking))
                _animator.SetBool(IsAttacking, true);
        }
    }

    void AnimationEnded()
    {
        _animator.SetBool(IsAttacking, false);
    }

    void FollowPlayer()
    {
        var target = _player.transform.position;
        var playerDistance = Vector3.Distance(target, transform.position);

        if (!PlayerInLos() || playerDistance > FollowDistance)
        {
            _navMeshAgent.enabled = true;
            _navMeshAgent.destination = target;
            if (!_animator.GetBool(IsMoving))
                _animator.SetBool(IsMoving, true);
        }
        else
        {
            _navMeshAgent.enabled = false;
            if (_animator.GetBool(IsMoving))
                _animator.SetBool(IsMoving, false);
        }
    }

    bool PlayerInLos()
    {
        var player = _player.transform.position;
        RaycastHit hit;
        return Physics.Raycast(transform.position, player - transform.position, out hit) &&
               hit.transform.CompareTag("Player");
    }

    bool PlayerInFront()
    {
        var fwd = transform.forward;
        var up = transform.up;
        var source = transform.position + up;
        var target = fwd * 30 + up;
        RaycastHit hit;
        Debug.DrawRay(source, target);
        return Physics.Raycast(source, target, out hit) && hit.transform.CompareTag("Player");
    }

    void FaceTarget()
    {
        var direction =
            (_player.transform.position /*+ new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))*/ -
             transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public void Pause(bool pause)
    {
        isPaused = pause;
    }

    public void Die()
    {
        _killCounter.AddKill();
        var pos = transform.position;
        var rot = transform.rotation;
        Instantiate(DeathPoof, pos, rot);
        _loot.Execute();
        Destroy(gameObject);
    }
}