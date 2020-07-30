namespace Dictionary.Services.Models.Account
{
    public class UserCredentialsModel
    {
        public string Username { get; }
        public string Password { get; }

        public UserCredentialsModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}