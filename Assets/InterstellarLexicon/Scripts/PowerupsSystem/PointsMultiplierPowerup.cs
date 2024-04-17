namespace AP.PowerupsSystem
{
    public class PointsMultiplierPowerup : DurationalPowerup
    {
        public float multiplier;

        public const float ORIGINAL_MULTIPLIER = 1.0f;

        public override void Activate()
        {
            base.Activate();
            GameManager.Instance.pointsMultiplierFromPowerup = multiplier;
        }

        public override void DeactivatePowerup()
        {
            base.DeactivatePowerup();
            GameManager.Instance.pointsMultiplierFromPowerup = ORIGINAL_MULTIPLIER;
        }
    }
}