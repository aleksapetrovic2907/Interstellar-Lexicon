using TMPro;
using UnityEngine;

namespace AP.UI
{
    public class GameDurationTimer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timer;

        private void LateUpdate()
        {
            timer.text = FormatTime((int)GameManager.Instance.GameDurationInSeconds);
        }

        public static string FormatTime(int secondsElapsed)
        {
            string minutes = string.Format("{0,2:D2}", secondsElapsed / 60);
            string seconds = string.Format("{0,2:D2}", secondsElapsed % 60);
            return $"{minutes}:{seconds}";
        }
    }
}