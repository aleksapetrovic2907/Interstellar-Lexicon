using DG.Tweening;
using UnityEngine;

namespace AP.UI
{
    public enum MenuState
    {
        Menu,
        Highscores,
        Modifiers
    }

    public class MainMenuContainersAnimator : MonoBehaviour
    {
        [Header("Containers")]
        [SerializeField] private RectTransform highscoresContainer;
        [SerializeField] private RectTransform menuContainer;
        [SerializeField] private RectTransform modifiersContainer;

        [Header("Animation Settings")]
        [SerializeField] private float duration;
        [SerializeField] private Ease ease;

        // This is the reference width on the Canvas Scaler. Therefore even when resolution is dynamically adjusted, this value does not need to change.
        private const float REFERENCE_WIDTH = 1920;
        
        private MenuState m_menuState = MenuState.Menu;
        private Sequence m_sequence;
        private bool m_isAnimating = false;

        public void DisplayHighscores()
        {
            if (m_menuState == MenuState.Highscores || m_isAnimating) { return; }

            m_isAnimating = true;

            m_sequence = DOTween.Sequence();
            m_sequence.Append(menuContainer.DOLocalMove(Vector2.right * REFERENCE_WIDTH, duration).SetEase(ease));
            m_sequence.Join(highscoresContainer.DOLocalMove(Vector2.zero, duration).SetEase(ease));
            m_sequence.Join(modifiersContainer.DOLocalMove(Vector2.right * 2 * REFERENCE_WIDTH, duration).SetEase(ease));
            m_sequence.OnComplete(() =>
            {
                m_menuState = MenuState.Highscores;
                m_isAnimating = false;
            }).Play();
        }

        [ContextMenu("DisplayMF")]
        public void DisplayModifiers()
        {
            if (m_menuState == MenuState.Modifiers || m_isAnimating) { return; }

            m_isAnimating = true;

            m_sequence = DOTween.Sequence();
            m_sequence.Append(menuContainer.DOLocalMove(Vector2.left * REFERENCE_WIDTH, duration).SetEase(ease));
            m_sequence.Join(highscoresContainer.DOLocalMove(Vector2.left * 2 * REFERENCE_WIDTH, duration).SetEase(ease));
            m_sequence.Join(modifiersContainer.DOLocalMove(Vector2.zero, duration).SetEase(ease));
            m_sequence.OnComplete(() =>
            {
                m_menuState = MenuState.Modifiers;
                m_isAnimating = false;
            }).Play();
        }

        [ContextMenu("DisplayMenu")]
        public void DisplayMenu()
        {
            if (m_menuState == MenuState.Menu || m_isAnimating) { return; }

            m_isAnimating = true;

            m_sequence = DOTween.Sequence();
            m_sequence.Append(menuContainer.DOLocalMove(Vector2.zero, duration).SetEase(ease));
            m_sequence.Join(highscoresContainer.DOLocalMove(Vector2.left * REFERENCE_WIDTH, duration).SetEase(ease));
            m_sequence.Join(modifiersContainer.DOLocalMove(Vector2.right * REFERENCE_WIDTH, duration).SetEase(ease));
            m_sequence.OnComplete(() =>
            {
                m_menuState = MenuState.Menu;
                m_isAnimating = false;
            }).Play();
        }
    }
}