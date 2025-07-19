using System.Collections.Generic;
using _Scripts.Cards;
using UnityEngine;

namespace _Scripts.Systems
{
    public class DeckSystem
    {
        private readonly List<Card> _deck = new();

        public void LoadDeck(List<Card> cards)
        {
            _deck.Clear();
            _deck.AddRange(cards);
        }
        private void Shuffle(List<Card> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
        public Card DrawCard()
        {
            if (_deck.Count == 0) return null;
            Card top = _deck[0];
            _deck.RemoveAt(0);
            return top;
        }
        public List<Card> GetDeck() => _deck;
    }
}