using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AP.ProjectileSystem;
using DG.Tweening;

namespace AP.UI
{
    public class ExperienceBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI levelValue;
        [SerializeField] private Slider experienceSlider;

        [Header("Level Up Text Sequence Data")]
        [SerializeField] private Vector3 levelUpScale;
        [SerializeField] private Color levelUpColor;
        [SerializeField] private float duration;
        [SerializeField] private Ease ease;

        private Sequence m_levelUpSequence = null;

        private void OnEnable()
        {
            ProjectilesManager.Instance.OnTargetShot += delegate { UpdateExperience(); };
            GameManager.Instance.OnLevelUp += UpdateLevel;
        }

        private void OnDisable()
        {
            ProjectilesManager.Instance.OnTargetShot -= delegate { UpdateExperience(); };
            GameManager.Instance.OnLevelUp -= UpdateLevel;
        }

        private void Awake()
        {
            m_levelUpSequence = DOTween.Sequence();
            Tween scaleUpAndBack = levelValue.transform.DOScale(levelUpScale, duration / 2f).SetLoops(2, LoopType.Yoyo).SetEase(ease);
            Tween changeColorAndBack = levelValue.DOColor(levelUpColor, duration / 2f).SetLoops(2, LoopType.Yoyo).SetEase(ease);
            m_levelUpSequence.Append(scaleUpAndBack).Join(changeColorAndBack);
        }

        private void Start() => UpdateExperience();

        private void UpdateExperience()
        {
            experienceSlider.value = GameManager.Instance.ExperienceProgressNormalized;
        }

        private void UpdateLevel(int level)
        {
            levelValue.text = $"LEVEL {level + 1}";
            m_levelUpSequence.Rewind();
            m_levelUpSequence.Play();
        }
    }
}