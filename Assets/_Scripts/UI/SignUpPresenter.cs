using _Scripts.Constants;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using TMPro;
using UnityEditor.Rendering.LookDev;

namespace _Scripts.UI
{
    public class SignUpPresenter : UIBaseView
    {
        [SerializeField] private Button fbButton;
        [SerializeField] private Button gmailButton;
        [SerializeField] private TMP_InputField gmailInputField;
        [SerializeField] private TMP_InputField passwordInputField;
        
        private FirebaseAuth _auth;
        private UserModel _userModel;

        private void Awake()
        {
            _auth = FirebaseAuth.DefaultInstance;
            _userModel = new UserModel();
        }

        public void SignUpWithEmailAndPassword()
        {
            string email = gmailInputField.text.ToString();
            string password = passwordInputField.text.ToString();
            if (email == null || password == null) return;
            _auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
                if (task.IsCanceled) {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted) {
                    Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }

                // Firebase user has been created.
                UIManager.Instance.ShowUIView(ViewsType.SignInView);
                AuthResult result = task.Result;
                Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                    result.User.DisplayName, result.User.UserId);
            });
        }
    }
}