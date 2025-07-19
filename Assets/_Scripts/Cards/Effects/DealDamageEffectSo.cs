using _Scripts.Players;
using UnityEngine;

namespace _Scripts.Cards.Effects
{
    [CreateAssetMenu(menuName = "Effects/DealDamageEffect")]
    public class DealDamageEffectSo : CardEffect
    {
        public int damageAmount;

        public override void Activate(Card self, PlayerController owner, PlayerController opponent)
        {
            if (opponent != null)
            {
                //opponent take damage
                opponent.Health.TakeDamage(damageAmount);
            }
        }
    }
}