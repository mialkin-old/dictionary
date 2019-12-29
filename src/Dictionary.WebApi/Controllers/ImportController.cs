using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Dictionary.Database.Models;
using Dictionary.Database.Repositories.Word;
using Dictionary.Services.Models.Export;
using Dictionary.Services.Models.Word;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.WebApi.Controllers
{
    [Route("import")]
    public class ImportController : Controller
    {
        private readonly IWordRepository _wordRepository;

        public ImportController(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile archive)
        {
            var ms = new MemoryStream();
            await archive.CopyToAsync(ms);

            string str = Encoding.UTF8.GetString(ms.ToArray());

            var words = JsonSerializer.Deserialize<List<WordDto>>(str);

            //foreach (var word in words)
            //{
            //    await _wordRepository.CreateAsync(word);
            //}

            return Ok();
        }
    }
}
