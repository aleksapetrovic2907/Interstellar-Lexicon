using UnityEngine;

namespace AP.PowerupsSystem.VisualEffects
{
    public class GainHealthVisualsHandler : PowerupVisualsHandler
    {
        [SerializeField] private ParticleSystem gainHealthEffect;

        public override void OnActivate()
        {
            gainHealthEffect.Play();
        }

        public override void OnDeactivate() { }
    }
}