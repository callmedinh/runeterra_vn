using _Scripts.Cards;
using _Scripts.Players;
using _Scripts.Utilities;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class OpponentPresenter : MonoBehaviour
    {
        [SerializeField] private Transform handArea;
        [SerializeField] private TMP_Text manaText;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private ObjectPool objectPool;

        [SerializeField] PlayerController opponent;

        private void OnEnable()
        {
            opponent.Hand.CardAdded += HandleCardAdded;
            opponent.Mana.ManaChanged += HandleManaChanged;
            manaText.text = opponent.Mana.CurrentMana.ToString();
            healthText.text = opponent.Health.CurrentHealth.ToString();
        }

        private void OnDisable()
        {
            opponent.Hand.CardAdded -= HandleCardAdded;
            opponent.Mana.ManaChanged -= HandleManaChanged;
        }
        private void HandleManaChanged()
        {
            manaText.text = opponent.Mana.CurrentMana.ToString();
        }

        private void HandleCardAdded(Card card)
        {
            GameObject obj = objectPool.GetPooledObject(card.type);
            CardUI cardUI = obj.GetComponent<CardUI>();
            DraggableCard draggableCard = obj.GetComponent<DraggableCard>();
            draggableCard.Setup(opponent, card);
            cardUI.Setup(card);
            
            obj.transform.SetParent(handArea);
        }
    }
}