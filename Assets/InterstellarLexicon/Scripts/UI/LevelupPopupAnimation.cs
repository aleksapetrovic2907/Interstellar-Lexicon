using UnityEngine;
using DG.Tweening;

namespace AP.UI
{
    public class LevelupPopupAnimation : MonoBehaviour
    {
        [SerializeField] private float targetScale;
        [SerializeField] private float duration;
        [SerializeField] private Ease scaleUpEase;
        [SerializeField] private Ease scaleDownEase;
        [SerializeField] private float interval;

        private Sequence m_popupSequence;

        private void Awake()
        {
            m_popupSequence = DOTween.Sequence();
            Tween scaleUp = transform.DOScale(targetScale, duration / 2f).SetEase(scaleUpEase);
            Tween scaleDown = transform.DOScale(Vector3.zero, duration / 2f).SetEase(scaleDownEase);
            m_popupSequence.Append(scaleUp).AppendInterval(interval).Append(scaleDown);
        }

        private void Start()
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            GameManager.Instance.OnLevelUp += _ => PlayPopupAnimation();
        }

        private void PlayPopupAnimation()
        {
            m_popupSequence.Rewind();
            m_popupSequence.Play();
        }
    }
}