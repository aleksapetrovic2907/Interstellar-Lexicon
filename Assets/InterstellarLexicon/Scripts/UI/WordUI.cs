using UnityEngine;
using TMPro;

namespace AP.UI
{
    public class WordUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private RectTransform blackBackground;

        private RectTransform m_rectTransform;
        private Transform titleLocationTr;
        private Camera m_mainCamera;

        private const float BACKGROUND_PADDING_X = 30f;
        private const float BACKGROUND_PADDING_Y = 12f;

        public void SetData(Transform titleLocation, string word)
        {
            gameObject.name = $"{word}_title";
            title.text = word;
            blackBackground.sizeDelta = new Vector2(title.preferredWidth + BACKGROUND_PADDING_X, blackBackground.sizeDelta.y + BACKGROUND_PADDING_Y);
            titleLocationTr = titleLocation;
            m_mainCamera = Camera.main;
            m_rectTransform = GetComponent<RectTransform>();
        }

        private void LateUpdate()
        {
            m_rectTransform.position = m_mainCamera.WorldToScreenPoint(titleLocationTr.position);
        }
    }
}