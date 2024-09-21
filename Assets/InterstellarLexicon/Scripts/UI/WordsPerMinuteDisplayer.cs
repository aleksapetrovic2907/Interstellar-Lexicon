using UnityEngine;
using TMPro;

namespace AP.UI
{
    public class WordsPerMinuteDisplayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI wpm;

        private void LateUpdate() => wpm.text = GameManager.Instance.WordsPerMinute.ToString();
    }
}