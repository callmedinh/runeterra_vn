using UnityEngine;

namespace _Scripts.Cards
{
    public class UnitFactory : CardFactory
    {
        public GameObject cardPrefab;
        public override Card CreateCard()
        {
            GameObject obj = Instantiate(cardPrefab);
            return null;
        }
    }
}