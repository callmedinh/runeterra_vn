using _Scripts.Cards;
using _Scripts.Players; 
using _Scripts.Utilities;
using TMPro;
using UnityEngine;
namespace _Scripts.UI
{
    public class GameplayPresenter : UIBaseView
    {
        [SerializeField] private Transform boardArea;
        [SerializeField] private Transform handArea;
        [SerializeField] private TMP_Text manaText;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] ObjectPool objectPool;
        [SerializeField] private PlayerController player;
        private void OnEnable()
        {
            player.Hand.OnCardAdded += HandOnOnCardAdded;
            player.Hand.OnCardPlayed += HandleOnCardPlayed;
            manaText.text = player.Mana.CurrentMana.ToString();
            healthText.text = player.Health.CurrentHealth.ToString();
        }

        private void OnDisable()
        {
            player.Hand.OnCardAdded -= HandOnOnCardAdded;
        }
        private void HandleOnCardPlayed()
        {
            manaText.text = player.Mana.CurrentMana.ToString();
        }

        private void HandOnOnCardAdded(Card card)
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