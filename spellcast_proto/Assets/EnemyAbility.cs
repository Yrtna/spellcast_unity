using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

public class EnemyAbility : MonoBehaviour
{
    [SerializeField] private Ability ability;
    // [SerializeField] private GameObject weaponHolder;
    private float _cooldownDuration;
    private float _nextReadyTime;

    // Start is called before the first frame update
    void Start()
    {
        Initialize(ability, gameObject);
    }

    private void Initialize(Ability selectedAbility, GameObject weaponHolderGameObject)
    {
        ability = selectedAbility;
        _cooldownDuration = ability.BaseCooldown;
        _nextReadyTime = _cooldownDuration + Time.time;
        ability.Initialize(weaponHolderGameObject);
    }


    // Update is called once per frame
    public bool Cast()
    {
        if (Time.time > _nextReadyTime)
        {
            _nextReadyTime = _cooldownDuration + Time.time;
            ability.TriggerAbility(gameObject.transform);
            return true;
        }

        return false;
    }
}