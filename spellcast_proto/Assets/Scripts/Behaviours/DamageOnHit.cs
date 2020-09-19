using System;
using Data;
using UnityEngine;

namespace Behaviours
{
    public class DamageOnHit : MonoBehaviour
    {
        public int Damage { get; set; }

        public string fromUnitType;

        public bool HasCollided = false;

        private void OnCollisionEnter(Collision other)
        {
            if (HasCollided)
                return;
            var health = other.gameObject.GetComponent<Health>();
            if (health == null)
                health = other.gameObject.GetComponentInParent<Health>();
            if (health != null && !health.gameObject.CompareTag(fromUnitType))
            {
                HasCollided = true;
                health.Damage(Damage);
            }
        }
    }
}