namespace Dictionary.Services.Configs
{
    public class AccountConfig
    {
        public string AdminPassword { get; set; }

        public AccountConfig()
        {
            
        }
        public AccountConfig(string adminPassword)
        {
            AdminPassword = adminPassword;
        }
    }
}