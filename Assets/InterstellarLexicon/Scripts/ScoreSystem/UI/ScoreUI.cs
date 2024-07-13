using UnityEngine;
using TMPro;

namespace AP.ScoreSystem.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI pointsTMP;
        [SerializeField] private TextMeshProUGUI wpmTMP;
        [SerializeField] private TextMeshProUGUI difficultyMultiplierTMP;

        public void Initialize(Score score)
        {
            pointsTMP.text = score.Points.ToString();
            wpmTMP.text = score.WPM.ToString();
            difficultyMultiplierTMP.text = score.DifficultyMultiplier.ToString();
        }
    }
}