using System.ComponentModel.DataAnnotations;

namespace Dictionary.Web.ViewModels.Login
{
    public class LoginVm
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}