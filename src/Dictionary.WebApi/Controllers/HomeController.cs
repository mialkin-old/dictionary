using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Services.Models.Word;
using Dictionary.Services.Services.Word;
using Dictionary.Shared.Filters.Word;
using Dictionary.WebApi.ViewModels.Home;
using Dictionary.WebApi.ViewModels.Word;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWordService _wordService;

        public HomeController(IWordService wordService)
        {
            _wordService = wordService;
        }
        public async Task<IActionResult> Index(WordListFilter filter)
        {
            IList<WordListServiceModel> words = await _wordService.ListAsync(filter);

            var model = new HomeIndexViewModel
            {
                Words = words.Select(x => new WordListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Translation = x.Translation,
                    Transcription = x.Transcription,
                    GenderId = x.GenderId,
                    LanguageId = x.LanguageId,
                }).ToList()
            };

            return View(model);
        }
    }
}