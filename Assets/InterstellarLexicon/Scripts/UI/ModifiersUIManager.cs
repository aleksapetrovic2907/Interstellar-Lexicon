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

        private const string DIFFICULTY_LABEL = "DIFFICULTY POINTS MULTIPLIER: ";

        private void Awake()
        {
            enemySpeedSlider.onValueChanged.AddListener(_ => UpdateEnemySpeed());
            enemyFrequencySlider.onValueChanged.AddListener(_ => UpdateEnemyFrequency());
            powerupSpeedSlider.onValueChanged.AddListener(_ => UpdatePowerupSpeed());
            powerupFrequencySlider.onValueChanged.AddListener(_ => UpdatePowerupFrequency());
        }

        private void UpdatePointsDifficultyTextValue()
        {
            pointsModifierValue.text = DIFFICULTY_LABEL + ModifierValueToString(Modifiers.PointsModifier);
        }

        private void UpdateEnemySpeed()
        {
            Modifiers.SetEnemySpeedModifier(enemySpeedSlider.value);
            enemySpeedValueTMP.text = ModifierValueToString(Modifiers.EnemySpeed);
            UpdatePointsDifficultyTextValue();
        }

        private void UpdateEnemyFrequency()
        {
            Modifiers.SetEnemyFrequencyModifier(enemyFrequencySlider.value);
            enemyFrequencyValueTMP.text = ModifierValueToString(Modifiers.EnemyFrequency);
            UpdatePointsDifficultyTextValue();
        }

        private void UpdatePowerupSpeed()
        {
            Modifiers.SetPowerupSpeedModifier(powerupSpeedSlider.value);
            powerupSpeedValueTMP.text = ModifierValueToString(Modifiers.PowerupSpeed);
            UpdatePointsDifficultyTextValue();
        }

        private void UpdatePowerupFrequency()
        {
            Modifiers.SetPowerupFrequencyModifier(powerupFrequencySlider.value);
            powerupFrequencyValueTMP.text = ModifierValueToString(Modifiers.PowerupFrequency);
            UpdatePointsDifficultyTextValue();
        }

        public void ResetToDefault()
        {
            Modifiers.ResetToDefault();

            enemySpeedSlider.value = Modifiers.EnemySpeed;
            enemySpeedValueTMP.text = ModifierValueToString(enemySpeedSlider.value);
            enemyFrequencySlider.value = Modifiers.EnemyFrequency;
            enemyFrequencyValueTMP.text = ModifierValueToString(enemyFrequencySlider.value);
            powerupSpeedSlider.value = Modifiers.PowerupSpeed;
            powerupSpeedValueTMP.text = ModifierValueToString(powerupSpeedSlider.value);
            powerupFrequencySlider.value = Modifiers.PowerupFrequency;
            powerupFrequencyValueTMP.text = ModifierValueToString(powerupFrequencySlider.value);
        }

        private static string ModifierValueToString(float value) => "x" + value.ToString("0.00");
    }
}