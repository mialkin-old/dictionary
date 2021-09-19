using System.ComponentModel.DataAnnotations;

namespace Dictionary.Web.Options
{
    public class LoginOptions
    {
        public const string Login = "Login";

        [Required(AllowEmptyStrings = false)]
        public string? Username { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string? Password { get; set; }
    }
}