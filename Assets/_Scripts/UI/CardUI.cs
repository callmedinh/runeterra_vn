using _Scripts.Cards;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class CardUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text cardNameText;
        [SerializeField] private TMP_Text attackIndexText;
        [SerializeField] private TMP_Text healthIndexText;
        [SerializeField] private TMP_Text manaIndexText;

        private Card _card;
        public void Setup(Card card)
        {
            _card = card;
            cardNameText.text = card.cardName;
            if (card is UnitCardSo unitCardSo)
            {
                attackIndexText.text = unitCardSo.attack.ToString();
                healthIndexText.text = unitCardSo.health.ToString();
                manaIndexText.text = unitCardSo.manaCost.ToString();
            }
        }
    }
}