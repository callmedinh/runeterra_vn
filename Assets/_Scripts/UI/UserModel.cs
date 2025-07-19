
using Firebase.Auth;

namespace _Scripts.UI
{
    public class UserModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }

        public void SetUser(FirebaseUser user)
        {
            UserId = user.UserId;
            Email = user.Email;
            DisplayName = user.DisplayName;
        }

        public void ClearUser()
        {
            UserId = null;
            Email = null;
            DisplayName = null;
        }
    }
}