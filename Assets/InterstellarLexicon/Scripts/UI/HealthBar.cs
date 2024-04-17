using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AP.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthValue;
        [SerializeField] private Slider healthSlider;

        private void OnEnable()
        {
            GameManager.Instance.OnHealthChange += delegate { UpdateHealth(); };
        }

        private void OnDisable()
        {
            GameManager.Instance.OnHealthChange -= delegate { UpdateHealth(); };
        }

        private void Start() => UpdateHealth();

        private void UpdateHealth()
        {
            healthValue.text = $"{GameManager.Instance.Health}/{GameManager.Instance.MaxHealth}";
            healthSlider.value = GameManager.Instance.HealthLeftNormalized;
        }
    }
}