using System.Collections.Generic;
using _Scripts.Constants;
using _Scripts.Utilities;
using UnityEngine;

namespace _Scripts.UI
{
    public class UIManager : Singleton<UIManager>
    {
        private Dictionary<ViewsType, UIBaseView> _uiMap =  new();
        [SerializeField] private SignInPresenter signInPresenter;
        [SerializeField] private SignUpPresenter signUpPresenter;
        [SerializeField] private GameplayPresenter gameplayPresenter;
        private UIBaseView _currentView;
        public override void Awake()
        {
            base.Awake();
            _uiMap.Add(ViewsType.SignInView, signInPresenter);
            _uiMap.Add(ViewsType.SingUpView, signUpPresenter);
            _uiMap.Add(ViewsType.GameplayView, gameplayPresenter);
            HideAllViews();
        }

        private void Start()
        {
            //ShowUIView(ViewsContants.GameplayView);
        }

        private void HideAllViews()
        {
            foreach (var view in _uiMap.Values)
            {
                view.Hide();
            }
        }
        public void ShowUIView(ViewsType viewName)
        {
            if (_uiMap.TryGetValue(viewName, out UIBaseView view))
            {
                if (_currentView != null)
                {
                    _currentView.Hide();
                }
                _currentView = view;
                _currentView.Show();
            }
        }
    }

    public enum ViewsType
    {
        SignInView,
        SingUpView,
        GameplayView,
    }
}