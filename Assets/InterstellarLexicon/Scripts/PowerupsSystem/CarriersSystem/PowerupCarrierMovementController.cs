using UnityEngine;
using DG.Tweening;

namespace AP.PowerupsSystem.CarriersSystem
{
    public class PowerupCarrierMovementController : MonoBehaviour
    {
        private Tween m_moveToEnd = null;

        public void SetMovementData(Vector3 start, Vector3 end, float speed)
        {
            transform.position = start;

            m_moveToEnd = transform
                .DOMove(end, speed)
                .SetSpeedBased(true)
                .OnComplete(delegate { PowerupCarriersManager.Instance.CarrierLeftViewport(); })
                .Play();
        }

        private void OnDestroy()
        {
            m_moveToEnd?.Kill();
        }
    }
}