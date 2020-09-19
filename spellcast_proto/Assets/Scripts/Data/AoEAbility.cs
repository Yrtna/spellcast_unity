using Behaviours;
using UnityEditor;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Abilities/New AoE Ability")]
    public class AoEAbility : Ability
    {
        private MousePositionManager _mousePositionManager;
        private GameObject _player;
        private Rigidbody _rigidbody;

        public override void Initialize(GameObject obj)
        {
            _player = GameObject.FindWithTag("Player");
            _mousePositionManager = _player.GetComponent<MousePositionManager>();
            _rigidbody = _player.GetComponent<Rigidbody>();
            // AbilityGuid = GUID.Generate();
        }

        public override void TriggerAbility(Transform spawn)
        {
        }
    }
}