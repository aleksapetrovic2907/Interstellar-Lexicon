using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using AP.ProjectileSystem;
using AP.ShadowHelpers;

namespace AP.EnemySystem
{
    public class EnemyInstanceManager : GloballyAccessibleBase<EnemyInstanceManager>
    {
        public List<Enemy> Enemies { get; private set; } = new List<Enemy>();
        public int EnemiesDestroyed { get; private set; } = 0;

        public event Action<Enemy> OnEnemyDestroyed;

        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Transform enemiesParent;
        [SerializeField] private Vector2 instantiateDelayRange;
        [SerializeField] private float delayDecreaseFactorPerLevel;

        private static Vector2 s_instViewportRangeY = new Vector2(0.15f, 0.85f);

        private Camera m_mainCamera;

        private void OnEnable()
        {
            TypingManager.Instance.OnWordSubmitted += TryFindEnemy;
            ProjectilesManager.Instance.OnTargetShot += TargetShot;
            PlanetBehaviour.Instance.OnHitByEnemy += EnemyCrashed;
            GameManager.Instance.OnLevelUp += ShortenInstantiatingDelay;
        }
        private void OnDisable()
        {
            TypingManager.Instance.OnWordSubmitted -= TryFindEnemy;
            ProjectilesManager.Instance.OnTargetShot -= TargetShot;
            PlanetBehaviour.Instance.OnHitByEnemy -= EnemyCrashed;
            GameManager.Instance.OnLevelUp += ShortenInstantiatingDelay;
        }

        private void Start()
        {
            m_mainCamera = Camera.main;
            StartCoroutine(StartInstantiatingCoroutine());
        }

        private IEnumerator StartInstantiatingCoroutine()
        {
            var randomDelay = instantiateDelayRange.GetRandomInRange();
            yield return new WaitForSeconds(randomDelay);
            InstantiateEnemy();
            StartCoroutine(StartInstantiatingCoroutine());
        }

        private void InstantiateEnemy()
        {
            var word = WordsManager.GetRandomWord();
            var enemyPreset = EnemyPresetsManager.Instance.GetPresetDataBasedOnWord(word);

            var enemy = Instantiate(enemyPrefab, enemiesParent).GetComponent<Enemy>();
            enemy.word = word;
            enemy.gameObject.name = word;
            enemy.SetSpriteData(enemyPreset.mainSprite, enemyPreset.whiteSprite);
            enemy.transform.localScale = enemyPreset.scale * Vector3.one;
            enemy.transform.position = GetSpawnPosition(enemy);
            enemy.GetComponent<EnemyMovementController>().StartMoving(EnvironmentReferences.Instance.planet, enemyPreset.speed);
            ShadowPathSetter.SetShadowPath(enemy.GetComponent<ShadowCaster2D>(), enemyPreset.shadowCaster2DPath);
            Enemies.Add(enemy);
        }

        private Vector2 GetSpawnPosition(Enemy enemy)
        {
            var shipBounds = enemy.SpriteRenderer.bounds;

            var x = m_mainCamera.ViewportToWorldPoint(Vector2.right).x + shipBounds.size.x / 2f;
            var randomY = m_mainCamera.ViewportToWorldPoint(Vector3.up * s_instViewportRangeY.GetRandomInRange()).y;

            return new Vector2(x, randomY);
        }

        private void TryFindEnemy(string word)
        {
            foreach (var enemy in Enemies)
            {
                if (!enemy.word.Equals(word)) continue;
                if (enemy.gettingShot) continue;
                ShootEnemy(enemy);
                GameManager.Instance.CorrectWordSubmitted();
            }
        }

        public void ShootEnemy(Enemy enemy)
        {
            enemy.GetReadyForShot();
            enemy.GetComponent<EnemyMovementController>().StopMoving();
            ProjectilesManager.Instance.ShootTarget(enemy.transform);
            EnemiesDestroyed++;
        }

        private void TargetShot(Transform target)
        {
            if (!target.TryGetComponent<Enemy>(out var enemy)) return;

            Enemies.Remove(enemy);
            OnEnemyDestroyed?.Invoke(enemy);
            Destroy(enemy.gameObject);
        }

        private void EnemyCrashed(Enemy enemy)
        {
            Enemies.Remove(enemy);
            Destroy(enemy.gameObject);
        }

        private void ShortenInstantiatingDelay(int level) => instantiateDelayRange *= delayDecreaseFactorPerLevel;
    }
}