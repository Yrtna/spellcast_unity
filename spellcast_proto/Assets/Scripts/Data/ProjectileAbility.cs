using Behaviours;
using UnityEditor;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Abilities/New Projectile Ability")]
    public class ProjectileAbility : Ability
    {
        public float projectileForce = 250f;
        public Rigidbody projectile;
        private Transform _bulletSpawn;
        
        public override void Initialize(GameObject obj)
        {
            _bulletSpawn = GameObject.FindWithTag("BulletSpawn").transform;
            AbilityGuid = GUID.Generate();
        }

        public override void TriggerAbility()
        {
            var clonedBullet = Instantiate(projectile, _bulletSpawn.position, _bulletSpawn.rotation) as Rigidbody;
            clonedBullet.AddForce(_bulletSpawn.transform.forward * projectileForce);
        }
    }
}
