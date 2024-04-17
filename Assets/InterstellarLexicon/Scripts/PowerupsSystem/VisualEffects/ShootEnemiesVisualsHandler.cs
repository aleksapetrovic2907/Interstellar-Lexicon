using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

namespace AP.PowerupsSystem.VisualEffects
{
    public class ShootEnemiesVisualsHandler : PowerupVisualsHandler
    {
        [SerializeField] private Volume volume;
        [SerializeField] private float tweenDuration;
        [SerializeField] private float activatedIntensity;
        [SerializeField] private float interval;
        [SerializeField] private Ease ease = Ease.InOutSine;

        private ChromaticAberration m_chromaticAberration;
        private Sequence m_sequence;

        private void Awake()
        {
            if (volume.profile.TryGet(out m_chromaticAberration))
            {
                m_sequence = DOTween.Sequence();

                m_sequence.Append(DOTween.To(() => m_chromaticAberration.intensity.value,
                    x => m_chromaticAberration.intensity.value = x,
                    activatedIntensity,
                    tweenDuration / 2f))
                    .SetEase(ease);

                m_sequence.AppendInterval(interval);

                m_sequence.Append(DOTween.To(() => m_chromaticAberration.intensity.value,
                    x => m_chromaticAberration.intensity.value = x,
                    0f,
                    tweenDuration / 2f))
                    .SetEase(ease);
            }
        }

        public override void OnActivate()
        {
            m_sequence.Restart();
        }

        public override void OnDeactivate() { }
    }
}