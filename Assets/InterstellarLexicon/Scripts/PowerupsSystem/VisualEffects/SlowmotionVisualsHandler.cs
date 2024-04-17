using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

namespace AP.PowerupsSystem.VisualEffects
{
    public class SlowmotionVisualsHandler : PowerupVisualsHandler
    {
        [SerializeField] private Volume volume;
        [ColorUsage(true, true)][SerializeField] private Color activatedColor;
        [ColorUsage(true, true)][SerializeField] private Color originalColor;
        [SerializeField] private float tweenDuration;
        [SerializeField] private GameObject slowmotionText;

        private ColorAdjustments m_colorAdjustments;
        private Tween m_tween = null;

        public override void OnActivate()
        {
            if (volume.profile.TryGet(out m_colorAdjustments))
            {
                m_tween = DOTween.To(() => m_colorAdjustments.colorFilter.value,
                    x => m_colorAdjustments.colorFilter.value = x,
                    activatedColor,
                    tweenDuration)
                    .Play();
            }

            slowmotionText.SetActive(true);
        }

        public override void OnDeactivate()
        {
            if (volume.profile.TryGet(out m_colorAdjustments))
            {
                m_tween = DOTween.To(() => m_colorAdjustments.colorFilter.value,
                    x => m_colorAdjustments.colorFilter.value = x,
                    originalColor,
                    tweenDuration)
                    .Play();
            }

            slowmotionText.SetActive(false);
        }
    }
}