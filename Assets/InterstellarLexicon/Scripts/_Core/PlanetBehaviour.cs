using System;
using UnityEngine;
using AP.EnemySystem;

namespace AP
{
    public class PlanetBehaviour : GloballyAccessibleBase<PlanetBehaviour>
    {
        public event Action<Enemy> OnHitByEnemy;

        [SerializeField] private ParticleSystem explosionVFX;

        private void Start() => GameManager.Instance.OnGameOver += DestroyPlanet;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent<Enemy>(out var enemy)) return;
            OnHitByEnemy?.Invoke(enemy);
        }

        [ContextMenu("test")]
        private void DestroyPlanet()
        {
            explosionVFX.transform.SetParent(null);
            explosionVFX.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}