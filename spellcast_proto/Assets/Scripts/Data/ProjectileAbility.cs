using Behaviours;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Abilities/New Projectile Ability")]
    public class ProjectileAbility : Ability
    {
        public float projectileForce = 250f;
        public Rigidbody projectile;

        private ProjectileShootTriggerable _launcher;
        public override void Initialize(GameObject obj)
        {
            _launcher = obj.GetComponent<ProjectileShootTriggerable>();
            _launcher.projectileForce = projectileForce;
            _launcher.projectile = projectile;
        }

        public override void TriggerAbility()
        {
            _launcher.Launch();
        }
    }
}
