namespace Dictionary.WebUi.Configs
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AccountConfig
    {
        public AccountConfig()
        {
            
        }
        public AccountConfig(string adminPassword)
        {
            AdminPassword = adminPassword;
        }
        public string AdminPassword { get; set; }
    }
}