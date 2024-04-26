using UnityEngine;
using TMPro;

namespace AP.UI
{
    public class TypedTextUIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;

        private void Start() => TypingManager.Instance.OnWordChanged += UpdateText;
        private void UpdateText(string text) => textMeshProUGUI.text = text;
    }
}