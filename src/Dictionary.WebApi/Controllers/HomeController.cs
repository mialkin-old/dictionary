using Microsoft.AspNetCore.Mvc;

namespace Dictionary.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}