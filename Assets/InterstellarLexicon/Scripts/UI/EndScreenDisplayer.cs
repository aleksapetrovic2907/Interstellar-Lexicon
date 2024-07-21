using UnityEngine;
using TMPro;
using DG.Tweening;
using AP.ScoreSystem.UI;

namespace AP.UI
{
    public class EndScreenDisplayer : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private float panelPopupDuration;
        [SerializeField] private Ease panelPopupEase;

        [Header("Data")]
        [SerializeField] private TextMeshProUGUI levelTMP;
        [SerializeField] private TextMeshProUGUI wordsTMP;
        [SerializeField] private TextMeshProUGUI wpmTMP;
        [SerializeField] private TextMeshProUGUI maxComboTMP;
        [SerializeField] private TextMeshProUGUI durationTMP;
        [SerializeField] private TextMeshProUGUI pointsTMP;

        private void Start() => GameManager.Instance.OnGameOver += DisplayScreen;

        private void DisplayScreen()
        {
            // Setup end game data.
            levelTMP.text = GameManager.Instance.Level.ToString();
            wordsTMP.text = GameManager.Instance.WordsWrittenCorrectly.ToString();
            wpmTMP.text = GameManager.Instance.WordsPerMinute.ToString();
            maxComboTMP.text = GameManager.Instance.HighestCombo.ToString();
            durationTMP.text = GameDurationTimer.FormatTime((int)GameManager.Instance.GameDurationInSeconds).ToString();
            pointsTMP.text = Formatter.FormatPoints(GameManager.Instance.Points);

            // Animate panel.
            panel.transform.DOScale(Vector3.one, panelPopupDuration).From(Vector3.zero).SetEase(panelPopupEase).Play();
            panel.SetActive(true);
        }
    }
}