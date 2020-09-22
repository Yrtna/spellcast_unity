using Behaviours;
using Ludiq.PeekCore;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Abilities/New ExpulseCone Ability")]
    public class ExpulseConeAbility : Ability
    {
        public float projectileForce;
        public Rigidbody projectile;
        public int spellsToCast = 8;
        public float radius = 1;
        public float coneSize = 60f;

        public override void Initialize(GameObject obj)
        {
        }

        public override void TriggerAbility(Transform spawn)
        {
            var offset = (360f - coneSize) / 2;
            var angleOffset = Quaternion.AngleAxis(offset, Vector3.up);
            var angle = coneSize / spellsToCast;
            for (var i = 0; i < spellsToCast; i++)
            {
                var rotation = Quaternion.AngleAxis(i * angle, Vector3.up);
                var direction = spawn.rotation * rotation * Vector3.forward;
                var position = spawn.position + (direction * radius);
                if (projectileForce > 0)
                    projectile.GetComponent<ProjectileMoveScript>().speed = projectileForce;
                var clonedBullet = Instantiate(projectile, position + Vector3.up, rotation * spawn.rotation);
                var damageOnHit = clonedBullet.AddComponent<DamageOnHit>();
                damageOnHit.Damage = damage;
                damageOnHit.fromUnitType = spawn.tag;
            }
        }
    }
}