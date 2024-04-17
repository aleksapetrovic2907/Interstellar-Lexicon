using UnityEngine;

namespace AP.EnemySystem
{
    public class EnemyVFXController : MonoBehaviour
    {
        [SerializeField] private GameObject explosionVFX;

        private void OnDestroy()
        {
            var explosion = Instantiate(explosionVFX);
            explosion.transform.localScale *= transform.localScale.x;
            explosion.transform.position = transform.position;
        }
    }
}