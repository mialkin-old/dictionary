namespace Dictionary.Services.Configs
{
    public class UserCredentialsConfig
    {
        public string Username { get; }
        public string Password { get; }

        public UserCredentialsConfig(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}