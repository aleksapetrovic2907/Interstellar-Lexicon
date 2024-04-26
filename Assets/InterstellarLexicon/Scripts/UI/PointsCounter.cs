using UnityEngine;
using TMPro;
using AP.ProjectileSystem;

namespace AP.UI
{
    public class PointsCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI counter;

        private void Start() => ProjectilesManager.Instance.OnTargetShot += _ => UpdateCounter();

        private void UpdateCounter()
        {
            counter.text = FormatPoints(GameManager.Instance.Points);
        }

        public static string FormatPoints(int points) => string.Format("{0,7:D7}", points); 
    }
}