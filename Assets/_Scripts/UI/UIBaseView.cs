using UnityEngine;

namespace _Scripts.UI
{
    public class UIBaseView : MonoBehaviour
    {
        public void Show()
        {
            this.gameObject.SetActive(true);
            OnShow();
        }

        public void Hide()
        {
            OnHide();
            this.gameObject.SetActive(false);
        }

        public virtual void OnShow()
        {
            
        }

        public virtual void OnHide()
        {
            
        }
    }
}