using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.WebUi.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult SignIn(string password)
        {
            if (password == "secret")
            {
                return Json(new {success = true});
            }

            return Json(new {success = false, errorMessage = "Wrong password!"});
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return null;
        }
    }
}