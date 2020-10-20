using System.Security.Claims;
using System.Threading.Tasks;
using Dictionary.Services.Models.Account;
using Dictionary.Services.Services.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.WebUi.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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

            bool valid = await _accountService.UserExists(new UserCredentials(username, password));
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