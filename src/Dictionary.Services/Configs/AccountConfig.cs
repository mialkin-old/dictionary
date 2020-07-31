namespace Dictionary.Services.Configs
{
    public class AccountConfig
    {
        public string AdminPassword { get; set; }

        public AccountConfig(string adminPassword)
        {
            AdminPassword = adminPassword;
        }
    }
}