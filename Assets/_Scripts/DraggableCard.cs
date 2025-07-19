using System;
using _Scripts.Cards;
using _Scripts.Players;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Scripts
{
    public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        CanvasGroup _canvasGroup;
        public Transform originalParent;
        private PlayerController _playerController;
        private Card _card;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Setup(PlayerController player, Card card)
        {
            _playerController = player;
            _card = card;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            originalParent = transform.parent;
            transform.SetParent(transform.root); // move to top UI layer
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.alpha = .5f;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.alpha = 1f;
            if (eventData.pointerEnter != null && eventData.pointerEnter.GetComponent<BoardZone>() != null)
            {
                if (_playerController.Hand.CanPlayCard(_card, _playerController.Mana))
                {
                    _playerController.Hand.PlayCard(_card, _playerController);
                    transform.SetParent(eventData.pointerEnter.transform);   
                }
                else
                {
                    transform.SetParent(originalParent);
                }
            }
            else
            {
                transform.SetParent(originalParent);
            }
        }
    }
}