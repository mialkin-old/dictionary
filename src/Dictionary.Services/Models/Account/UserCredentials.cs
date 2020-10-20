namespace Dictionary.Services.Models.Account
{
    public class UserCredentials
    {
        public string Username { get; }
        public string Password { get; }

        public UserCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}