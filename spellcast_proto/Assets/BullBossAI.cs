using System;
using System.Collections;
using System.Collections.Generic;
using Behaviours;
using Data;
using UnityEngine;
using UnityEngine.AI;

public class BullBossAI : MonoBehaviour, IKillable
{
    private Animator _bossAnimator;

    public EnemyAbility expulseCircleAbility;
    public int expulseAbilitySpellCount = 1;
    public float bossSpellRotationSpeed = 1f;

    public EnemyAbility expulseConeAbility;
    public int coneSize = 1;

    public EnemyAbility laserEyes;
    public Transform rightEye;
    public Transform leftEye;
    private Transform _target;

    public float dizzyDuration;

    public float circleProcDistance;
    public float coneProcDistance;

    public int circleCastCount;
    public int coneCastCount;

    public int maxCircleCount;
    public int maxConeCount;

    private NavMeshAgent _agent;

    public BossState _bossState = BossState.Idle;

    private Health _health;
    private bool isDead = false;

    private KillCounter _killCounter;

    private static readonly int Defy = Animator.StringToHash("defy");
    private static readonly int Jump = Animator.StringToHash("jump");
    private static readonly int Attack03 = Animator.StringToHash("attack_03");
    private static readonly int IsDizzy = Animator.StringToHash("IsDizzy");
    private static readonly int Walk = Animator.StringToHash("walk");
    private static readonly int Death = Animator.StringToHash("die");
    private static readonly int IsDead = Animator.StringToHash("IsDead");

    private bool bossActive = false;
    private AudioManagerScript _audioManager;

    // Start is called before the first frame update
    void Start()
    {
        _bossAnimator = GetComponent<Animator>();
        _target = GameObject.FindWithTag("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
        _health = GetComponent<Health>();
        _killCounter = GameObject.FindWithTag("KillCounter").GetComponent<KillCounter>();
        _audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManagerScript>();
    }

    private void OnEnable()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        Invoke(nameof(ActivateBoss), 4f);
    }

    private void ActivateBoss()
    {
        GetComponent<CapsuleCollider>().enabled = true;
        bossActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bossActive)
            return;
        if (_bossState == BossState.Die)
            BossDeath();
        if (isDead || _bossState == BossState.Dizzy)
            return;
        var distance = (_target.position - transform.position).magnitude;

        if (circleCastCount > 0 && _bossState == BossState.Circle)
        {
            CastAbilityInCircleAndSpin();
        }
        else if (coneCastCount > 0 && _bossState == BossState.Cone)
        {
            CastWaveInCone();
            if (distance < circleProcDistance)
            {
                _bossState = BossState.Circle;
                circleCastCount = maxCircleCount;
                coneCastCount = 0;
                StopFollowing();
            }
        }
        else if (_bossState == BossState.Follow)
        {
            FollowPlayer();
            CastLaserEyes();
        }

        if (circleCastCount != 0 || coneCastCount != 0)
            return;
        if (distance < circleProcDistance)
        {
            _bossState = BossState.Circle;
            circleCastCount = maxCircleCount;
            coneCastCount = 0;
            StopFollowing();
        }
        else if (distance < coneProcDistance)
        {
            _bossState = BossState.Cone;
            coneCastCount = maxConeCount;
            circleCastCount = 0;
            StopFollowing();
        }
        else if (circleCastCount <= 0 && coneCastCount <= 0)
        {
            circleCastCount = 0;
            coneCastCount = 0;
            _bossState = BossState.Follow;
        }
    }

    void FollowPlayer()
    {
        if (isDead)
            return;
        circleCastCount = 0;
        coneCastCount = 0;
        SetFollow();
        _agent.SetDestination(_target.position);
    }

    void StopFollowing()
    {
        _agent.SetDestination(transform.position);
    }

    void CastLaserEyes()
    {
        if (isDead)
            return;
        var eyesAbility = ((AlternatingProjectileAbility) laserEyes.ability);
        eyesAbility.leftEye = leftEye;
        eyesAbility.rightEye = rightEye;
        eyesAbility.target = _target;
        laserEyes.Cast();
        _audioManager.PlayOneShot("laser", 0.2f);
    }

    // jump
    void CastAbilityInCircleAndSpin()
    {
        if (isDead)
            return;
        ((ExpulseCircleAbility) expulseCircleAbility.ability).spellsToCast = expulseAbilitySpellCount;
        transform.Rotate(0, bossSpellRotationSpeed * Time.deltaTime, 0);
        _bossAnimator.SetTrigger(Jump);
    }

    public void AttackJump()
    {
        if (isDead)
            return;
        circleCastCount -= 1;
        expulseCircleAbility.Cast();
        _audioManager.PlayOneShot("pound", 0.4f);
        if (circleCastCount == 0)
            SetDizzy();
    }

    // attack_03
    void CastWaveInCone()
    {
        if (isDead)
            return;
        var direction = _target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        ((ExpulseConeAbility) expulseConeAbility.ability).coneSize = coneSize;
        // transform.Rotate(0, bossSpellRotationSpeed * Time.deltaTime, 0);
        _bossAnimator.SetTrigger(Attack03);
    }

    public void Attack3()
    {
        if (isDead)
            return;
        coneCastCount -= 1;
        expulseConeAbility.Cast();
        _audioManager.PlayOneShot("smash", 0.4f);
    }

    public void SetDizzy()
    {
        if (isDead)
            return;
        _bossState = BossState.Dizzy;
        _bossAnimator.SetBool(IsDizzy, true);
        Invoke(nameof(SetFollow), dizzyDuration);
        _health.DamageMultiplier = 5;
    }

    public void SetFollow()
    {
        if (isDead)
            return;
        _bossState = BossState.Follow;
        _bossAnimator.SetBool(IsDizzy, false);
        _bossAnimator.SetTrigger(Walk);
        _health.DamageMultiplier = 1;
    }


    public enum BossState
    {
        Follow,
        Cone,
        Circle,
        Dizzy,
        Idle,
        Die
    }

    public void BossDeath()
    {
        if (!isDead)
            _bossAnimator.SetTrigger(Death);
        isDead = true;
    }

    public void Die()
    {
        _bossAnimator.SetBool(IsDead, true);
        StopFollowing();
        GetComponent<CapsuleCollider>().enabled = false;
        _bossState = BossState.Die;
        _bossAnimator.SetTrigger(Death);
        _bossAnimator.SetBool(IsDizzy, false);
        isDead = true;
        _killCounter.AddKill();
    }
}