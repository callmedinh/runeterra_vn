using UnityEngine;

namespace _Scripts.Cards
{
    public enum CardType
    {
        Unit, Spell, Herro
    }
    public abstract class Card : ScriptableObject
    {
        public string id;
        public string cardName;
        public string description;
        public Sprite artwork;
        public int manaCost;
        public CardType type;
    }
}