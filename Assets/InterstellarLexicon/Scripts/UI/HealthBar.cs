using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AP.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthValue;
        [SerializeField] private Slider healthSlider;

        private void Start()
        {
            SubscribeToEvents();
            UpdateHealth();
        }

        private void SubscribeToEvents()
        {
            GameManager.Instance.OnHealthChange += _ => UpdateHealth();
        }

        private void UpdateHealth()
        {
            healthValue.text = $"{GameManager.Instance.Health}/{GameManager.Instance.MaxHealth}";
            healthSlider.value = GameManager.Instance.HealthLeftNormalized;
        }
    }
}