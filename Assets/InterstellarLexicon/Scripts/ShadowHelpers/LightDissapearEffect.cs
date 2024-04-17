using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;
using Unity.Collections;

namespace AP.ShadowHelpers
{
    public class LightDissapearEffect : MonoBehaviour
    {
        [SerializeField] private float duration;

        private Light2D m_light2D;

        private void Start()
        {
            m_light2D = GetComponent<Light2D>();
            DOTween.To(() => m_light2D.intensity, x => m_light2D.intensity = x, 0, duration).Play();
        }
    }
}