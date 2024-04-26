using UnityEngine;
using DG.Tweening;

namespace AP.CameraSystem
{
    public class CameraShaker : MonoBehaviour
    {
        [SerializeField] private float duration;
        [SerializeField] private float strength = 1;
        [SerializeField] private int vibrato = 10;

        private Tween m_cameraShake = null;

        private void Start() => PlanetBehaviour.Instance.OnHitByEnemy += _ => ShakeCamera();

        private void ShakeCamera()
        {
            if (m_cameraShake != null)
            {
                m_cameraShake.Rewind();
                m_cameraShake.Kill();
            }

            m_cameraShake = transform.DOShakePosition(duration, strength, vibrato, 90f, false, true, ShakeRandomnessMode.Harmonic).Play();
        }
    }
}