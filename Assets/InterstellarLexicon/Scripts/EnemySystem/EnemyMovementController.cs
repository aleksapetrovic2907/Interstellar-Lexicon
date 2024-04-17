using UnityEngine;
using DG.Tweening;

namespace AP.EnemySystem
{
    public class EnemyMovementController : MonoBehaviour
    {
        private Tween m_moveTween = null;

        public void StartMoving(Transform target, float speed)
        {
            m_moveTween = transform
                .DOMove(target.position, speed)
                .SetSpeedBased(true)
                .Play();
        }

        public void StopMoving() => m_moveTween.Kill();
        private void OnDestroy() => StopMoving();
    }
}