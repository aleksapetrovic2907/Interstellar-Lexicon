using UnityEngine;
using DG.Tweening;

namespace AP.UI
{
    public class BottomBlockController : MonoBehaviour
    {
        [SerializeField] private RectTransform block;
        [SerializeField] private float hideDuration;
        [SerializeField] private Ease hideEase;

        private void Start() => GameManager.Instance.OnGameOver += HideBlock;

        private void HideBlock()
        {
            Vector2 targetPosition = new(block.anchoredPosition.x, -block.anchoredPosition.y);
            block.DOAnchorPos(targetPosition, hideDuration).SetEase(hideEase).Play();
        }
    }
}