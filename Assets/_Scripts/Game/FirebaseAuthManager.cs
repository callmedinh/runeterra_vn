using System;
using _Scripts.Utilities;
using Firebase.Auth;
using UnityEngine;

namespace _Scripts.Managers
{
    public class FirebaseAuthManager : Singleton<FirebaseAuthManager>
    {
        public FirebaseAuth Auth { get; private set; }
        public FirebaseUser CurrentUser { get; private set; }
        public event Action<FirebaseUser> OnUserSignedIn;
        public event Action OnUserSignedOut;
        public override void Awake()
        {
            base.Awake();
            InitializeFirebase();

        }
        void InitializeFirebase() {
            Auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
            Auth.StateChanged += OnAuthStateChanged;
            OnAuthStateChanged(this, null);
        }

        void OnAuthStateChanged(object sender, System.EventArgs eventArgs) {
            if (Auth.CurrentUser != CurrentUser) {
                bool signedIn = CurrentUser != Auth.CurrentUser && Auth.CurrentUser != null
                                                         && Auth.CurrentUser.IsValid();
                if (!signedIn && CurrentUser != null) {
                    Debug.Log("Signed out " + CurrentUser.UserId);
                    OnUserSignedOut?.Invoke();
                }
                CurrentUser = Auth.CurrentUser;
                if (signedIn) {
                    Debug.Log("Signed in " + CurrentUser.UserId);
                    OnUserSignedIn?.Invoke(CurrentUser);
                }
            }
        }

        void OnDestroy() {
            Auth.StateChanged -= OnAuthStateChanged;
            Auth = null;
        }
    }
}