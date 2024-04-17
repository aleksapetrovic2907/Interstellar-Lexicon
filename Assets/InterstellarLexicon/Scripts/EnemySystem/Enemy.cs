using UnityEngine;
using DG.Tweening;
using AP.UI;

namespace AP.EnemySystem
{
    public class Enemy : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer => mainSpriteRenderer;

        public string word = string.Empty;
        public bool gettingShot = false;

        [SerializeField] private SpriteRenderer mainSpriteRenderer;
        [SerializeField] private SpriteRenderer whiteSpriteRenderer; // Activated when getting ready for shot.
        [SerializeField] private GameObject wordTitlePrefab;
        [SerializeField] private Transform titleLocation;

        private static readonly float s_colorTweenDuration = .35f;
        private static readonly Ease s_colorTweenEase = Ease.InSine;
        private Tween colorTween = null;
        private WordUI m_title;

        private void Start()
        {
            m_title = Instantiate(wordTitlePrefab, WordTitlesCanvas.Instance.transform).GetComponent<WordUI>();
            m_title.SetData(titleLocation, word);
        }

        public void GetReadyForShot()
        {
            gettingShot = true;
            colorTween = whiteSpriteRenderer.DOFade(1f, s_colorTweenDuration).SetEase(s_colorTweenEase).Play();
            Destroy(m_title.gameObject);
        }

        public void SetSpriteData(Sprite main, Sprite white)
        {
            mainSpriteRenderer.sprite = main;
            whiteSpriteRenderer.sprite = white;
        }

        private void OnDestroy()
        {
            colorTween?.Kill();
            if (m_title != null) Destroy(m_title.gameObject);
        }
    }
}