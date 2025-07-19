using _Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using TMPro;

namespace _Scripts.UI
{
    public class SignInPresenter : UIBaseView
    {
        [SerializeField] private TMP_InputField gmailInputField;
        [SerializeField] private TMP_InputField passwordInputField;
        [SerializeField] private Button fbButton;
        [SerializeField] private Button gmailButton;
        [SerializeField] private Button loginButton;

        private FirebaseAuth _auth;
        private UserModel _userModel;

        private void Start()
        {
            _userModel = new UserModel();
        }

        private void OnEnable()
        {
            FirebaseAuthManager.Instance.OnUserSignedIn += HandleSignedIn;
            FirebaseAuthManager.Instance.OnUserSignedOut += HandleSignedOut;
        }

        private void HandleSignedIn(FirebaseUser user)
        {
            Debug.Log("Tự động gọi khi đăng nhập: " + user.Email);
            _userModel.SetUser(user);
            // Load scene / cập nhật UI
        }

        private void HandleSignedOut()
        {
            Debug.Log("Đã đăng xuất");
            _userModel.ClearUser();
        }

        private void SignInWithEmailAndPassword()
        {
            string email = gmailInputField.text;
            string password = passwordInputField.text;
            if (email == null || password == null) return;
            _auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
                if (task.IsCanceled) {
                    Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted) {
                    Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }

                AuthResult result = task.Result;
                if (_userModel != null)
                {
                    _userModel.SetUser(result.User);
                }
                Debug.LogFormat("User signed in successfully: {0} ({1})",
                    result.User.DisplayName, result.User.UserId);
            });
        }
    }
}