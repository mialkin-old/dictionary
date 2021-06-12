using System.Security.Claims;
using System.Threading.Tasks;
using Dictionary.Web.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Dictionary.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly LoginOptions _loginOptions;

        public AccountController(IOptions<LoginOptions> loginOptions)
        {
            _loginOptions = loginOptions.Value;
        }

        [HttpGet]
        public IActionResult Info()
        {
            return Json(User.Identity.IsAuthenticated ? new { isLoggedIn = true } : new { isLoggedIn = false });
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string username, string password)
        {
            if (User.Identity.IsAuthenticated)
                return Json(new { success = false, errorMessage = "You are already authenticated!" });

            bool valid = username == _loginOptions.Username && password == _loginOptions.Password;
            if (!valid)
                return Json(new { success = false, errorMessage = "Invalid credentials!" });

            var claim = new Claim(ClaimTypes.Role, "user");
            var claimsIdentity = new ClaimsIdentity(new[] { claim }, "user");
            var claimsPrincipal = new ClaimsPrincipal(new[] { claimsIdentity });

            await HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties { IsPersistent = true });

            return Json(new { success = true });
        }

        [HttpGet]
        [Authorize]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}