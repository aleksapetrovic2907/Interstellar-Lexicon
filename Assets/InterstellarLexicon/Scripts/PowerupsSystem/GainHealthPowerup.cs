namespace AP.PowerupsSystem
{
    public class GainHealthPowerup : Powerup
    {
        public int gainAmount;

        public override void Activate()
        {
            base.Activate();
            GameManager.Instance.GainHealth(gainAmount);
            PowerupsManager.Instance.isAnyPowerupActive = false;
        }
    }
}