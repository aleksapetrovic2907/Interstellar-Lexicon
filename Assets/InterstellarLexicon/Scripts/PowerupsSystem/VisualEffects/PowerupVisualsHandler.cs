using UnityEngine;

namespace AP.PowerupsSystem.VisualEffects
{
    public abstract class PowerupVisualsHandler : MonoBehaviour
    {
        public abstract void OnActivate();
        public abstract void OnDeactivate();
    }
}