using _Scripts.Players;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Scripts
{
    public class BoardZone : MonoBehaviour, IDropHandler
    {
        [SerializeField] Transform boardZone;
        [SerializeField] private PlayerController playerController;
        public void OnDrop(PointerEventData eventData)
        {
            var draggedObj = eventData.pointerDrag;
            if (draggedObj == null) return;
            draggedObj.transform.SetParent(boardZone);
        }
    }
}