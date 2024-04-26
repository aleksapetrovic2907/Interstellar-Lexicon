using UnityEngine;

namespace AP.EnemySystem
{
    public class EnemyVFXController : MonoBehaviour
    {
        [SerializeField] private GameObject explosionVFX;

        private bool m_isAppQuitting = false;

        private void OnApplicationQuit() => m_isAppQuitting = true;

        private void OnDestroy()
        {
            if (m_isAppQuitting) { return; }

            var explosion = Instantiate(explosionVFX);
            explosion.transform.localScale *= transform.localScale.x;
            explosion.transform.position = transform.position;
        }
    }
}