using System;
using UnityEngine;

namespace Bloomkin.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int   _maxHealth             = 100;
        [SerializeField] private float _invincibilityDuration = 0.5f;

        public static event Action<int, int> OnHealthChanged; // (current, max)
        public static event Action           OnDeath;
        public static event Action<int>      OnDamaged;
        public static event Action<int>      OnHealed;

        private int   _currentHealth;
        private bool  _isInvincible;
        private float _invincibilityTimer;

        public int   CurrentHealth  => _currentHealth;
        public int   MaxHealth      => _maxHealth;
        public bool  IsAlive        => _currentHealth > 0;
        public float HealthPercent  => (float)_currentHealth / _maxHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        private void Update()
        {
            if (_isInvincible)
            {
                _invincibilityTimer -= Time.deltaTime;
                if (_invincibilityTimer <= 0f)
                    _isInvincible = false;
            }
        }

        public int TakeDamage(int amount)
        {
            if (!IsAlive || _isInvincible || amount <= 0) return 0;

            int dealt = Mathf.Min(amount, _currentHealth);
            _currentHealth -= dealt;
            _isInvincible       = true;
            _invincibilityTimer = _invincibilityDuration;

            OnDamaged?.Invoke(dealt);
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

            if (_currentHealth <= 0) HandleDeath();
            return dealt;
        }

        public int Heal(int amount)
        {
            if (!IsAlive || amount <= 0) return 0;

            int healed = Mathf.Min(amount, _maxHealth - _currentHealth);
            _currentHealth += healed;

            OnHealed?.Invoke(healed);
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
            return healed;
        }

        public void FullHeal()
        {
            int healed = _maxHealth - _currentHealth;
            _currentHealth = _maxHealth;
            if (healed > 0)
            {
                OnHealed?.Invoke(healed);
                OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
            }
        }

        private void HandleDeath()
        {
            _currentHealth = 0;
            OnDeath?.Invoke();
            Core.GameManager.Instance?.TriggerGameOver();
        }
    }
}
