using _Scripts.Players;
using UnityEngine;

namespace _Scripts.Cards.Effects
{
    [CreateAssetMenu(menuName = "Effects/SummonEffect")]
    public class SummonEffectSo : CardEffect
    {
        public override void Activate(Card self, PlayerController owner, PlayerController opponent)
        {
            //summon the unit
        }
    }
}