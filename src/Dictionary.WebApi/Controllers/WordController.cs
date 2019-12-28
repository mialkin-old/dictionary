using System.Collections.Generic;
using System.Threading.Tasks;
using Dictionary.Services.Models.Word;
using Dictionary.Services.Services.Word;
using Dictionary.WebApi.ViewModels;
using Dictionary.WebApi.ViewModels.Word;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.WebApi.Controllers
{
    [Route("word")]
    public class WordController : Controller
    {
        private readonly IWordService _wordService;

        public WordController(IWordService wordService)
        {
            _wordService = wordService;
        }

        [Route("list")]
        public IActionResult List()
        {
            return new JsonResult(new { Count = 5, Words = new List<string> { "one", "two", "three", "four", "five" } });
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody]WordCreateViewModel model)
        {
            await _wordService.CreateAsync(new WordCreateServiceModel { 
                Name = model.Name,
                Translation = model.Translation,
                Transcription = model.Transcription,
                GenderId = model.GenderId,
                LanguageId = model.LanguageId
            });

            return Ok();
        }
    }
}