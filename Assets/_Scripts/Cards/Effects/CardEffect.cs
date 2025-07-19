using _Scripts.Players;
using UnityEngine;

namespace _Scripts.Cards.Effects
{
    public abstract class CardEffect : ScriptableObject
    {
        public abstract void Activate(Card self, PlayerController owner, PlayerController opponent);
    }
}