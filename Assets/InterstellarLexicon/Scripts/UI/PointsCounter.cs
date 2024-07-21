using UnityEngine;
using TMPro;
using AP.ProjectileSystem;
using AP.ScoreSystem.UI;

namespace AP.UI
{
    public class PointsCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI counter;

        private void Start() => ProjectilesManager.Instance.OnTargetShot += _ => UpdateCounter();

        private void UpdateCounter()
        {
            counter.text = Formatter.FormatPoints(GameManager.Instance.Points);
        }
    }
}