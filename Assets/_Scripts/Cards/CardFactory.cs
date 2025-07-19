using UnityEngine;

namespace _Scripts.Cards
{
    public abstract class CardFactory : MonoBehaviour
    {
        public abstract Card CreateCard();
    }
}