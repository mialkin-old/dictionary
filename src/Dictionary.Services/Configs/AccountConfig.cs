namespace Dictionary.Services.Configs
{
    public class AccountConfig
    {
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }

        public AccountConfig(string adminUsername, string adminPassword)
        {
            AdminUsername = adminUsername;
            AdminPassword = adminPassword;
        }
    }
}