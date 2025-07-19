using System.Collections.Generic;
using _Scripts.Cards.Effects;
using UnityEngine;

namespace _Scripts.Cards
{
    [CreateAssetMenu(menuName = "Cards/SpellCard")]
    public class SpellCardSo : Card
    {
        public SpellSpeed speed;
        public List<CardEffect> effects;
    }

    public enum SpellSpeed
    {
        Slow,
        Fast,
        Burst
    }
}