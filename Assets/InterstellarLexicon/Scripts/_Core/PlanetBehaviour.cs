using System;
using UnityEngine;
using AP.EnemySystem;

namespace AP
{
    public class PlanetBehaviour : GloballyAccessibleBase<PlanetBehaviour>
    {
        public event Action<Enemy> OnHitByEnemy;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<Enemy>(out var enemy)) return;
            OnHitByEnemy?.Invoke(enemy);
        }
    }
}