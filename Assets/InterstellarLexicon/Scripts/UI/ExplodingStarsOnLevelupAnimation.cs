using System.Collections;
using UnityEngine;

namespace AP.UI
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ExplodingStarsOnLevelupAnimation : MonoBehaviour
    {
        [SerializeField] private ParticleSystem.MinMaxCurve levelUpEmissionRate;
        [SerializeField] private float duration;

        private ParticleSystem explodingStarsParticleSystem;
        private ParticleSystem.EmissionModule m_emissionModule;
        private ParticleSystem.MinMaxCurve m_originalEmissionRate;

        private void Awake()
        {
            explodingStarsParticleSystem = GetComponent<ParticleSystem>();
            m_emissionModule = explodingStarsParticleSystem.emission;
            m_originalEmissionRate = m_emissionModule.rateOverTime;
        }

        private void Start()
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            GameManager.Instance.OnLevelUp += _ => PlayLevelUpAnimation();
        }

        private void PlayLevelUpAnimation()
        {
            ResetEmission();
            StartCoroutine(StartAnimationCoroutine());
        }

        private void ResetEmission()
        {
            StopCoroutine(StartAnimationCoroutine());
            m_emissionModule.rateOverTime = m_originalEmissionRate;
        }

        private IEnumerator StartAnimationCoroutine()
        {
            m_emissionModule.rateOverTime = levelUpEmissionRate;
            yield return new WaitForSeconds(duration);
            m_emissionModule.rateOverTime = m_originalEmissionRate;
        }
    }
}