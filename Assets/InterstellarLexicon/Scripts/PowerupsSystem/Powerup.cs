using AP.PowerupsSystem.VisualEffects;
using UnityEngine;

namespace AP.PowerupsSystem
{
    public abstract class Powerup : MonoBehaviour
    {
        public PowerupType powerupType;
        public PowerupVisualsHandler powerupVisualsHandler;

        public virtual void Activate()
        {
            powerupVisualsHandler.OnActivate();
        }
    }
}