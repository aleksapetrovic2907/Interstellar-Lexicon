namespace AP
{
    public static class Modifiers
    {
        public static float PointsModifier { get; private set; }

        public static float EnemySpeed;
        public static float EnemyFrequency;
        public static float PowerupSpeed;
        public static float PowerupFrequency;

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
    }
}