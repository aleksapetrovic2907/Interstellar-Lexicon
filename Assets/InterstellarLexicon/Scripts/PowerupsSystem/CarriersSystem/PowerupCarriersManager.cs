using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AP.PowerupsSystem.CarriersSystem
{
    public class PowerupCarriersManager : GloballyAccessibleBase<PowerupCarriersManager>
    {
        [SerializeField] private Transform carrierStart, carrierEnd;
        [SerializeField] private float carrierSpeed;
        [SerializeField] private Vector2 carrierSpawnDelayRange;
        [SerializeField] private Transform carriersParent;
        [SerializeField] private List<PowerupCarrier> powerupCarrierPrefabs;
        [SerializeField] private GameObject explosionPrefab;

        private PowerupCarrier m_currentPowerupCarrier = null;

        private void Start()
        {
            SubscribeToEvents();
            StartCoroutine(StartSpawningCarriersCoroutine());
        }

        private void SubscribeToEvents()
        {
            TypingManager.Instance.OnWordSubmitted += TryFindCarrier;
            GameManager.Instance.OnGameOver += GameOver;
        }

        private void TryFindCarrier(string word)
        {
            if (m_currentPowerupCarrier == null) { return; }
            if (m_currentPowerupCarrier.word != word) { return; }

            PowerupsManager.Instance.ActivatePowerup(m_currentPowerupCarrier.powerupType);
            Instantiate(explosionPrefab, m_currentPowerupCarrier.transform.position, explosionPrefab.transform.rotation);
            Destroy(m_currentPowerupCarrier.gameObject);
            m_currentPowerupCarrier = null;
            GameManager.Instance.CorrectWordSubmitted();
        }

        private IEnumerator StartSpawningCarriersCoroutine()
        {
            yield return new WaitUntil(() => m_currentPowerupCarrier == null);
            yield return new WaitUntil(() => !PowerupsManager.Instance.isAnyPowerupActive);

            var randomDelay = (carrierSpawnDelayRange * Modifiers.PowerupFrequency).GetRandomInRange();
            yield return new WaitForSeconds(randomDelay);

            SpawnCarrier();
            StartCoroutine(StartSpawningCarriersCoroutine());
        }

        private void SpawnCarrier()
        {
            m_currentPowerupCarrier = Instantiate(powerupCarrierPrefabs.GetRandomElement(), carriersParent);
            m_currentPowerupCarrier.GetComponent<PowerupCarrierMovementController>().SetMovementData(carrierStart.position, carrierEnd.position, carrierSpeed * Modifiers.PowerupSpeed);
        }

        public void CarrierLeftViewport()
        {
            Destroy(m_currentPowerupCarrier.gameObject);
            m_currentPowerupCarrier = null;
        }

        private void GameOver()
        {
            StopAllCoroutines();

            if (m_currentPowerupCarrier != null)
            {
                Destroy(m_currentPowerupCarrier.gameObject);
            }
        }
    }
}