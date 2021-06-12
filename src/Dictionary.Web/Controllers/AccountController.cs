using System.Security.Claims;
using System.Threading.Tasks;
using Dictionary.Web.Options;
using Dictionary.Web.ViewModels.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Dictionary.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : Controller
    {
        private readonly LoginOptions _loginOptions;

        public AccountController(IOptions<LoginOptions> loginOptions)
        {
            _loginOptions = loginOptions.Value;
        }

        [Route("info")]
        [HttpGet]
        public IActionResult Info()
        {
            return Json(User.Identity.IsAuthenticated ? new { isLoggedIn = true } : new { isLoggedIn = false });
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginVm model)
        {
            if (User.Identity.IsAuthenticated)
                return Json(new { success = false, errorMessage = "You are already authenticated!" });

            bool valid = model.Username == _loginOptions.Username && model.Password == _loginOptions.Password;
            if (!valid)
                return Json(new { success = false, errorMessage = "Invalid credentials!" });

            var claim = new Claim(ClaimTypes.Role, "user");
            var claimsIdentity = new ClaimsIdentity(new[] { claim }, "user");
            var claimsPrincipal = new ClaimsPrincipal(new[] { claimsIdentity });

            await HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties { IsPersistent = true });

            return Json(new { success = true });
        }

        [Route("logout")]
        [HttpGet]
        [Authorize]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}