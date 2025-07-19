using System.Collections.Generic;
using _Scripts.Cards;
using _Scripts.Systems;
using UnityEngine;

namespace _Scripts.Players
{
    public class PlayerController : MonoBehaviour
    {
        public ManaSystem Mana { get; private set; }
        public HealthSystem Health { get; private set; }
        public BoardSystem Board { get; private set; }
        public DeckSystem Deck { get; private set; }
        public HandSystem Hand { get; private set; }

        public List<Card> cards = new(); 

        private void Awake()
        {
            Mana = new ManaSystem();
            Health = new HealthSystem(this);
            Board = new BoardSystem();
            Deck = new DeckSystem();
            Hand = new HandSystem();
        }

        public void Init()
        {
            cards = new List<Card>(Resources.LoadAll<Card>("Cards/Unit Cards"));
            Deck.LoadDeck(cards);
            for (int i = 0; i < 4; i++)
            {
                Hand.AddCardToHand(Deck.DrawCard());
            }
        }
        public void StartTurn(int turn)
        {
            Mana.StartTurn(turn);
            Hand.AddCardToHand(Deck.DrawCard());
        }
    }
}