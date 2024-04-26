using UnityEngine;
using TMPro;
using DG.Tweening;
using AP.ProjectileSystem;

namespace AP.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ComboCounter : MonoBehaviour
    {
        [Header("Scale Tween Data")]
        [SerializeField] private Vector3 scaleIncrease;
        [SerializeField] private float scaleDuration;
        [SerializeField] private Ease scaleEase;

        private TextMeshProUGUI m_counter;
        private Tween m_counterPunchTween = null;

        private void Awake()
        {
            m_counter = GetComponent<TextMeshProUGUI>();
            m_counterPunchTween = m_counter.transform.DOScale(scaleIncrease, scaleDuration).SetEase(scaleEase).SetLoops(2, LoopType.Yoyo).SetRelative(true);
        }

        private void Start()
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            PlanetBehaviour.Instance.OnHitByEnemy += _ => UpdateCounter();
            ProjectilesManager.Instance.OnTargetShot += _ => UpdateCounter();
        }

        private void UpdateCounter()
        {
            var combo = GameManager.Instance.CurrentCombo;

            if (combo == 0)
            {
                m_counter.text = string.Empty;
            }
            else
            {
                m_counter.text = $"COMBO x{combo}";
                m_counterPunchTween.Rewind();
                m_counterPunchTween.Play();
            }
        }
    }
}