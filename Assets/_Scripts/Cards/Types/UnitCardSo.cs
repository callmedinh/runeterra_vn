using UnityEngine;

namespace _Scripts.Cards
{
    [CreateAssetMenu(menuName = "Cards/UnitCard")]
    public class UnitCardSo : Card
    {
        public int attack;
        public int health;
    }
}