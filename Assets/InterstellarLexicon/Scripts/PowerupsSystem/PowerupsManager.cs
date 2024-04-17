using System.Collections.Generic;
using UnityEngine;

namespace AP.PowerupsSystem
{
    public class PowerupsManager : GloballyAccessibleBase<PowerupsManager>
    {
        public bool isAnyPowerupActive = false;

        [SerializeField] private List<Powerup> powerups;

        public void ActivatePowerup(PowerupType powerupType)
        {
            FindPowerupByType(powerupType).Activate();
        }

        private Powerup FindPowerupByType(PowerupType powerupType)
        {
            var index = 0;

            for (int i = 0; i < powerups.Count; i++)
            {
                if (powerups[i].powerupType != powerupType) continue;
                index = i;
                break;
            }

            return powerups[index];
        }
    }
}