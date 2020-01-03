using Microsoft.AspNetCore.Mvc;

namespace Dictionary.WebUi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}