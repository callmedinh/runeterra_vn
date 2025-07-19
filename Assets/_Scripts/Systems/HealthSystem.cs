using _Scripts.Players;

namespace _Scripts
{
    public class HealthSystem
    {
        private PlayerController _playerController;
        public int CurrentHealth { get; private set; }

        public HealthSystem(PlayerController playerController)
        {
            this._playerController = playerController;
            CurrentHealth = 20;
        }

        public void Heal(int amount)
        {
            CurrentHealth += amount;
        }

        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
            if (CurrentHealth <= 0)
            {
                //Trigger lose game event
            }
        }
    }
}