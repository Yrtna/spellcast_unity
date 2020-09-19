using Behaviours;
using Ludiq.PeekCore;
using UnityEditor;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Abilities/New Projectile Ability")]
    public class ProjectileAbility : Ability
    {
        public float projectileForce = 250f;
        public Rigidbody projectile;
        
        public override void Initialize(GameObject obj)
        {
            // AbilityGuid = GUID.Generate();
        }

        public override void TriggerAbility(Transform spawn)
        {
            var clonedBullet = Instantiate(projectile, spawn.position + spawn.forward + spawn.up, spawn.rotation) as Rigidbody;
            clonedBullet.AddForce(spawn.transform.forward * projectileForce);
            var damageOnHit = clonedBullet.AddComponent<DamageOnHit>();
            damageOnHit.Damage = damage;
            damageOnHit.fromUnitType = spawn.tag;
        }

    }
}
