using Behaviours;
using Ludiq.PeekCore;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Abilities/New ExpulseCircle Ability")]
    public class ExpulseCircleAbility : Ability
    {
        public float projectileForce;
        public Rigidbody projectile;
        public int spellsToCast = 8;
        public float radius = 1;

        public override void Initialize(GameObject obj)
        {
        }

        public override void TriggerAbility(Transform spawn)
        {
            var angle = 360f / spellsToCast;
            var rotationOffset = Quaternion.AngleAxis(Random.Range(0f, 120f), Vector3.up);
            for (var i = 0; i < spellsToCast; i++)
            {
                var rotation = Quaternion.AngleAxis(i * angle, Vector3.up);
                var direction = rotationOffset * rotation * Vector3.forward;
                var position = spawn.position + direction * radius;
                if (projectileForce > 0)
                    projectile.GetComponent<ProjectileMoveScript>().speed = projectileForce;
                var clonedBullet = Instantiate(projectile, position + Vector3.up, rotation);
                var damageOnHit = clonedBullet.AddComponent<DamageOnHit>();
                damageOnHit.Damage = damage;
                damageOnHit.fromUnitType = spawn.tag;
            }
        }
    }
}