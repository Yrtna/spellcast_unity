using Behaviours;
using UnityEditor;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Abilities/New Dash Ability")]
    public class DashAbility : Ability
    {
        private MousePositionManager _mousePositionManager;
        private GameObject _player;
        private Rigidbody _rigidbody;

        public float dashMultiplier = 100f;

        public override void Initialize(GameObject obj)
        {
            _player = GameObject.FindWithTag("Player");
            _mousePositionManager = _player.GetComponent<MousePositionManager>();
            _rigidbody = _player.GetComponent<Rigidbody>();
            // AbilityGuid = GUID.Generate();
        }

        public override void TriggerAbility(Transform spawn)
        {
            var direction = (_mousePositionManager.GetMousePos() - _player.transform.position).normalized;
            _rigidbody.AddForce(direction * dashMultiplier, ForceMode.VelocityChange);
        }
    }
}