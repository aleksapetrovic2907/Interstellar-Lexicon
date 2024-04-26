using AP.EnemySystem;

namespace AP.PowerupsSystem
{
    public class ShootAllEnemiesPowerup : Powerup
    {
        public override void Activate()
        {
            base.Activate();

            foreach (var enemy in EnemyInstanceManager.Instance.Enemies)
            {
                EnemyInstanceManager.Instance.ShootEnemy(enemy);
            }

            PowerupsManager.Instance.isAnyPowerupActive = false;
        }
    }
}
