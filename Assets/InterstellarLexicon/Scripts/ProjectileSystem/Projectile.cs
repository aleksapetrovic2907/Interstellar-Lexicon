#pragma warning disable 618

using System;
using UnityEngine;
using DG.Tweening;

namespace AP.ProjectileSystem
{
    public class Projectile : MonoBehaviour
    {
        public event Action OnHit;

        [SerializeField] private ParticleSystem particles;

        private Tween m_pathTween = null;
        private const float PARTICLES_DESTRUCTION_DELAY = .35f;

        public void ShootTarget(Vector3[] path, float speed, AnimationCurve curve)
        {
            m_pathTween = transform
                .DOPath(path, speed, PathType.CatmullRom)
                .SetSpeedBased(true)
                .SetEase(curve)
                .OnComplete(delegate
                {
                    OnHit?.Invoke();
                    particles.enableEmission = false;
                    particles.transform.parent = null;
                    Destroy(particles.gameObject, PARTICLES_DESTRUCTION_DELAY);
                })
                .Play();
        }

        private void OnDestroy() => m_pathTween?.Kill();
    }
}