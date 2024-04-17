using UnityEngine;

namespace AP.PowerupsSystem
{
    public class SlowmotionPowerup : DurationalPowerup
    {
        public float slowmotionTimescale;

        private const float ORIGINAL_TIMESCALE = 1.0f;

        public override void Activate()
        {
            base.Activate();
            Time.timeScale = slowmotionTimescale;
        }

        public override void DeactivatePowerup()
        {
            base.DeactivatePowerup();
            Time.timeScale = ORIGINAL_TIMESCALE;
        }
    }
}