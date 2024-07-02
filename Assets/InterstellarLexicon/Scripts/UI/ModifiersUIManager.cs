using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AP.UI
{
    public class ModifiersUIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI pointsModifierValue;

        [SerializeField] private Slider enemySpeedSlider;
        [SerializeField] private TextMeshProUGUI enemySpeedValueTMP;

        [SerializeField] private Slider enemyFrequencySlider;
        [SerializeField] private TextMeshProUGUI enemyFrequencyValueTMP;

        [SerializeField] private Slider powerupSpeedSlider;
        [SerializeField] private TextMeshProUGUI powerupSpeedValueTMP;

        [SerializeField] private Slider powerupFrequencySlider;
        [SerializeField] private TextMeshProUGUI powerupFrequencyValueTMP;

        private void Awake()
        {
            enemySpeedSlider.onValueChanged.AddListener(_ => UpdateEnemySpeed());
            enemyFrequencySlider.onValueChanged.AddListener(_ => UpdateEnemyFrequency());
            powerupSpeedSlider.onValueChanged.AddListener(_ => UpdatePowerupSpeed());
            powerupFrequencySlider.onValueChanged.AddListener(_ => UpdatePowerupFrequency());
        }

        private void UpdateEnemySpeed()
        {
            Modifiers.SetEnemySpeedModifier(enemySpeedSlider.value);
            pointsModifierValue.text = ModifierValueToString(Modifiers.PointsModifier);
        }

        private void UpdateEnemyFrequency()
        {
            Modifiers.SetEnemyFrequencyModifier(enemyFrequencySlider.value);
            pointsModifierValue.text = ModifierValueToString(Modifiers.PointsModifier);
        }

        private void UpdatePowerupSpeed()
        {
            Modifiers.SetPowerupSpeedModifier(powerupSpeedSlider.value);
            pointsModifierValue.text = ModifierValueToString(Modifiers.PointsModifier);
        }

        private void UpdatePowerupFrequency()
        {
            Modifiers.SetPowerupFrequencyModifier(powerupFrequencySlider.value);
            pointsModifierValue.text = ModifierValueToString(Modifiers.PointsModifier);
        }

        private static string ModifierValueToString(float value) => "x" + value.ToString();
    }
}