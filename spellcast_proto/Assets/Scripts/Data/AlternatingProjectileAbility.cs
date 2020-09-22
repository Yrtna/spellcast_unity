using Behaviours;
using Ludiq.PeekCore;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Abilities/New AlternatingProjectile Ability")]
    public class AlternatingProjectileAbility : Ability
    {
        public float projectileForce;
        public Rigidbody projectile;

        public Transform leftEye;
        public Transform rightEye;

        public Transform target;

        private bool pingPong = false;

        public override void Initialize(GameObject obj)
        {
        }

        public override void TriggerAbility(Transform spawn)
        {
            if (projectileForce > 0)
                projectile.GetComponent<ProjectileMoveScript>().speed = projectileForce;

            var mySpawn = pingPong == false ? leftEye : rightEye;
            pingPong = !pingPong;
            var direction = target.position - mySpawn.position;
            var rotation = Quaternion.LookRotation(direction, Vector3.up);
            var clonedBullet =
                Instantiate(projectile, mySpawn.position, rotation) as Rigidbody;
            var damageOnHit = clonedBullet.AddComponent<DamageOnHit>();
            damageOnHit.Damage = damage;
            damageOnHit.fromUnitType = spawn.tag;
        }
    }
}