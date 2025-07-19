using System;
using _Scripts.Cards;
using _Scripts.Cores;
using _Scripts.Players;
using _Scripts.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private Transform handArea;
        [SerializeField] private TMP_Text manaText;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private Button endTurnButton;
        [SerializeField] private ObjectPool objectPool;

        [SerializeField] private PlayerController player;
        public event Action EndTurnButtonClicked;
        private void OnEnable()
        {
            player.Hand.CardAdded += HandleCardAdded;
            player.Mana.ManaChanged += OnManaChanged;
            manaText.text = player.Mana.CurrentMana.ToString();
            healthText.text = player.Health.CurrentHealth.ToString();
            endTurnButton.onClick.AddListener(OnEndTurnButtonClicked);
        }

        private void OnDisable()
        {
            player.Hand.CardAdded -= HandleCardAdded;
            player.Mana.ManaChanged -= OnManaChanged;
        }

        private void OnManaChanged()
        {
            manaText.text = player.Mana.CurrentMana.ToString();
        }

        private void OnEndTurnButtonClicked()
        {
            TurnManager.Instance.EndTurn();
            EndTurnButtonClicked?.Invoke();
        }
        private void HandleCardAdded(Card card)
        {
            GameObject obj = objectPool.GetPooledObject(card.type);
            CardUI cardUI = obj.GetComponent<CardUI>();
            DraggableCard draggableCard = obj.GetComponent<DraggableCard>();
            draggableCard.Setup(player, card);
            cardUI.Setup(card);
            
            obj.transform.SetParent(handArea);
        }
    }
}