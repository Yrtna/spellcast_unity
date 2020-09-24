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

        public GameObject CastProjector;
        private GameObject _projectorInstance;
        public float dashMultiplier = 100f;

        private Vector3 movementToApply;
        private Vector3 directionToApply;

        public override void Initialize(GameObject obj)
        {
            _player = GameObject.FindWithTag("Player");
            _mousePositionManager = _player.GetComponent<MousePositionManager>();
            _rigidbody = _player.GetComponent<Rigidbody>();
            // AbilityGuid = GUID.Generate();
        }


        public void PreCastAbility()
        {
            var direction = (_mousePositionManager.GetMousePos() - _player.transform.position);
            if (Physics.Raycast(_player.gameObject.transform.position, direction, out RaycastHit hit, dashMultiplier,
                ~LayerMask.GetMask("Spells")))
            {
                var dist = hit.distance;
                directionToApply = direction.normalized * (dist * 0.9f);
                movementToApply = _player.transform.position + directionToApply;
            }
            else
            {
                if (direction.magnitude > dashMultiplier)
                    direction = direction.normalized * dashMultiplier;
                directionToApply = direction;
                movementToApply = _player.transform.position + directionToApply;
            }

            _projectorInstance = Instantiate(CastProjector, movementToApply + Vector3.up * 5,
                Quaternion.AngleAxis(90f, Vector3.right));
        }

        public override void TriggerAbility(Transform spawn)
        {
            _player.transform.position = movementToApply;
            Destroy(_projectorInstance);
        }
    }
}