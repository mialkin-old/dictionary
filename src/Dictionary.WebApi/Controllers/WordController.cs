using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.WebApi.Controllers
{
    public class WordController : Controller
    {
        public IActionResult Index()
        {
            return new JsonResult(new { Count = 5, Words = new List<string> { "one", "two", "three", "four", "five" } });
        }
    }
}