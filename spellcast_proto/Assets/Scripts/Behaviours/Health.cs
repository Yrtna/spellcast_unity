using System;
using Data;
using Ludiq.PeekCore;
using UnityEngine;

namespace Behaviours
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private int currentHealth;

        public int DamageMultiplier = 1;
        private ScrollingTextManager _scrollingTextManager;
        public int MaxHealth => maxHealth;

        public int CurrentHealth
        {
            get => currentHealth;
            private set => currentHealth = value;
        }

        void Start()
        {
            CurrentHealth = MaxHealth;
            _scrollingTextManager = GameObject.FindWithTag("ScrollingTextManager").GetComponent<ScrollingTextManager>();
        }

        public void Damage(int qty)
        {
            qty *= DamageMultiplier;
            if (qty < 0)
                throw new Exception("Health.TakeDamage(int qty) => qty must be >= 0");
            CurrentHealth -= qty;
            if (_scrollingTextManager != null)
                _scrollingTextManager.NewDamage(qty, transform);
            if (CurrentHealth > 0) return;
            CurrentHealth = 0;
            Die();
        }

        public void Heal(int qty)
        {
            if (qty < 0)
                throw new Exception("Health.Heal(int qty) => qty must be >= 0");
            CurrentHealth += qty;
            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;
            _scrollingTextManager.NewHeal(qty, transform);
        }

        private void Die()
        {
            gameObject.GetComponent<IKillable>().Die();
        }
    }
}