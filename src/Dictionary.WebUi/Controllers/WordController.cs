using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dictionary.Services.Models.Word;
using Dictionary.Services.Services.Word;
using Dictionary.Shared.Filters.Word;
using Dictionary.WebUi.ViewModels.Word;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.WebUi.Controllers
{
    [Route("word")]
    public class WordController : Controller
    {
        private readonly IWordService _wordService;
        private readonly IMapper _mapper;

        public WordController(IWordService wordService, IMapper mapper)
        {
            _wordService = wordService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody]WordCreateViewModel model)
        {
            await _wordService.CreateAsync(_mapper.Map<WordCreateServiceModel>(model));

            return Ok();
        }

        [Route("list")]
        public async Task<IActionResult> List(WordListFilter filter)
        {
            filter.OrderByDescending = true;
            filter.OrderByPropertyName = "Created";

            IList<WordListServiceModel> result = await _wordService.ListAsync(filter);

            return Ok(result);
        }
    }
}