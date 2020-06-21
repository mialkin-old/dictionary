using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dictionary.Services.Models.Word;
using Dictionary.Services.Services.Word;
using Dictionary.Shared.Filters;
using Dictionary.WebUi.Misc;
using Dictionary.WebUi.ViewModels.Word;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.WebUi.Controllers
{
    [Route("api/{controller}")]
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
        public async Task<IActionResult> Create([FromBody]WordCreateVm model)
        {
            if (await _wordService.WordExists(model.Name, model.LanguageId))
            {
                var result = new StandardResult<Empty>
                {
                    Error = $"Word (name: \"{model.Name}\", language ID: {model.LanguageId}) already exists. It was not saved."
                };

                return Ok(result);
            }

            if (string.IsNullOrWhiteSpace(model.Transcription))
                model.Transcription = null;

            int id = await _wordService.CreateAsync(_mapper.Map<WordCreateServiceModel>(model));

            return Ok(new StandardResult<int> { Data = id });
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody]WordUpdateVm model)
        {
            if (string.IsNullOrWhiteSpace(model.Transcription))
                model.Transcription = null;
            
            await _wordService.UpdateAsync(_mapper.Map<WordUpdateServiceModel>(model));

            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] WordDeleteVm model)
        {
            await _wordService.DeleteAsync(model.Id);

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

        [Route("search")]
        public async Task<IActionResult> Search(WordSearchFilter filter)
        {
            filter.OrderByDescending = true;
            filter.OrderByPropertyName = "Created";

            IList<WordListServiceModel> result = await _wordService.SearchAsync(filter);

            return Ok(result);
        }
    }
}