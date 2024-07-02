namespace AP
{
    public static class Modifiers
    {
        public static float PointsModifier { get; private set; }

        public static float EnemySpeed { get; private set; }
        public static float EnemyFrequency { get; private set; }
        public static float PowerupSpeed { get; private set; }
        public static float PowerupFrequency { get; private set; }

        public static void ResetToDefault()
        {
            EnemySpeed = 1f;
            EnemyFrequency = 1f;
            PowerupSpeed = 1f;
            PowerupFrequency = 1f;
            EvaluatePointsModifier();
        }

        public static void EvaluatePointsModifier()
        {
            float enemyModifiers = EnemySpeed * EnemyFrequency;
            float powerupsModifiers = 1 / (PowerupSpeed * PowerupFrequency);

            // Calculate overall points modifier
            PointsModifier = enemyModifiers * powerupsModifiers;
        }

#region SETTERS
        public static void SetEnemySpeedModifier(float value)
        {
            EnemySpeed = value;
            EvaluatePointsModifier();
        }

        public static void SetEnemyFrequencyModifier(float value)
        {
            EnemyFrequency = value;
            EvaluatePointsModifier();
        }

        public static void SetPowerupSpeedModifier(float value)
        {
            PowerupSpeed = value;
            EvaluatePointsModifier();
        }

        public static void SetPowerupFrequencyModifier(float value)
        {
            PowerupFrequency = value;
            EvaluatePointsModifier();
        }
        #endregion
    }
}