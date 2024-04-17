using System.Collections;
using UnityEngine;

namespace AP.PowerupsSystem
{
    public abstract class DurationalPowerup : Powerup
    {
        public float duration;

        public override void Activate()
        {
            base.Activate();
            StartCoroutine(DeactivatePowerupInSeconds(duration));
            PowerupsManager.Instance.isAnyPowerupActive = true;
        }

        public IEnumerator DeactivatePowerupInSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            DeactivatePowerup();
        }

        public virtual void DeactivatePowerup()
        {
            powerupVisualsHandler.OnDeactivate();
            PowerupsManager.Instance.isAnyPowerupActive = false;
        }
    }
}