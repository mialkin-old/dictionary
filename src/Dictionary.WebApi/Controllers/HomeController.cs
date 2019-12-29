using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public HomeController(IWordService wordService, IMapper mapper)
        {
            _wordService = wordService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(WordListFilter filter)
        {
            filter.LanguageId = 2;
            filter.OrderByDescending = true;
            filter.OrderByPropertyName = "Created";

            IList<WordListServiceModel> words = await _wordService.ListAsync(filter);

            var model = new HomeIndexViewModel
            {
                Words = _mapper.Map<List<WordListViewModel>>(words)
            };

            return View(model);
        }
    }
}