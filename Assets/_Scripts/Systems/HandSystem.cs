using System;
using System.Collections.Generic;
using _Scripts.Cards;
using _Scripts.Players;
using UnityEngine;

namespace _Scripts.Systems
{
    public class HandSystem
    {
        private List<Card> _handCards = new();
        public readonly int MaxHandSize = 6;
        public event Action<Card> CardAdded;
        public event Action OnCardPlayed;

        public void AddCardToHand(Card card)
        {
            if (_handCards.Count > MaxHandSize) return;
            _handCards.Add(card);
            Debug.Log("Card added, invoking event");
            CardAdded?.Invoke(card);
        }

        public void RemoveCardFromHand(Card card)
        {
            if (_handCards.Contains(card))
            {
                _handCards.Remove(card);
            }
        }

        public bool CanPlayCard(Card card, ManaSystem manaSystem)
        {
            return manaSystem.HasEnough(card.manaCost);
        }

        public void PlayCard(Card card, PlayerController owner)
        {
            if (!CanPlayCard(card, owner.Mana)) return;
            owner.Mana.Spend(card.manaCost);
            OnCardPlayed?.Invoke();
            RemoveCardFromHand(card);
        }
    }
}