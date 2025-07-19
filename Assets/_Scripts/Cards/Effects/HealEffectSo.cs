using _Scripts.Players;
using UnityEngine;

namespace _Scripts.Cards.Effects
{
    [CreateAssetMenu(menuName = "Effects/HealEffect")]
    public class HealEffectSo : CardEffect
    {
        public int healAmount;

        public override void Activate(Card self, PlayerController owner, PlayerController opponent)
        {
            if (owner != null)
            {
                //heal for owner
                owner.Health.Heal(healAmount);
            }
        }
    }
}