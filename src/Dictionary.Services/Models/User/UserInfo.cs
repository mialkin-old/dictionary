namespace Dictionary.Services.Models.User
{
    public class UserInfo
    {
        public string Username { get; private set; }

        public UserInfo(string username)
        {
            Username = username;
        }
    }
}