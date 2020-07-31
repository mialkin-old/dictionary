namespace Dictionary.Services.Configs
{
    public class AdminCredentials
    {
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }

        public AdminCredentials(string adminUsername, string adminPassword)
        {
            AdminUsername = adminUsername;
            AdminPassword = adminPassword;
        }
    }
}