using UnityEngine;

namespace AP
{
    public class ViewportPositioner : MonoBehaviour
    {
        [SerializeField] private Vector2 positionInViewport;
        [SerializeField] private bool positionOnAwake = true;
        
        private Camera m_mainCamera;

        private void Awake()
        {
            m_mainCamera = Camera.main;
            
            if (!positionOnAwake) return;
            PositionInViewport();
        }

        public void PositionInViewport()
        {
            var position = Camera.main.ViewportToWorldPoint(positionInViewport);
            position.z = transform.position.z;

            transform.position = position;
        }
    }
}