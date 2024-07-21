using UnityEngine;
using TMPro;
using AP.UI;

namespace AP.ScoreSystem.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI positionTMP;
        [SerializeField] private TextMeshProUGUI pointsTMP;
        [SerializeField] private TextMeshProUGUI wpmTMP;
        [SerializeField] private TextMeshProUGUI difficultyMultiplierTMP;

        public void Initialize(int position, Score score)
        {
            positionTMP.text = $"#{position + 1}";
            pointsTMP.text = Formatter.FormatPoints(score.Points);
            wpmTMP.text = score.WPM.ToString();
            difficultyMultiplierTMP.text = ModifiersUIManager.ModifierValueToString(score.DifficultyMultiplier);
        }
    }
}