namespace Dictionary.Services.Models.User
{
    public class UserInfoModel
    {
        public string Username { get; private set; }

        public UserInfoModel(string username)
        {
            Username = username;
        }
    }
}