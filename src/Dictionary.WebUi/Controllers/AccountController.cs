using System;
using System.Security.Claims;
using Dictionary.WebUi.Configs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.WebUi.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountConfig _accountConfig;

        public AccountController(AccountConfig accountConfig)
        {
            _accountConfig = accountConfig;
        }
        
        [HttpGet]
        public IActionResult Info()
        {
            return Json(User.Identity.IsAuthenticated ? new { loggedIn = true } : new { loggedIn = false });
        }

        [HttpPost]
        public IActionResult LogIn(string password)
        {
            if (User.Identity.IsAuthenticated)
                throw new InvalidOperationException("You are already authenticated");

            if (password != _accountConfig.AdminPassword) return Json(new { success = false, errorMessage = "Wrong password!" });

            var claim = new Claim(ClaimTypes.Role, "user");
            var claimsIdentity = new ClaimsIdentity(new[] { claim }, "user");
            var claimsPrincipal = new ClaimsPrincipal(new[] { claimsIdentity });

            HttpContext.SignInAsync(claimsPrincipal);

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