using System.IO;
using System.Threading.Tasks;
using Dictionary.Services.Services.Import;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.WebUi.Controllers
{
    [Authorize]
    [Route("import")]
    public class ImportController : Controller
    {
        private readonly IImportService _importService;

        public ImportController(IImportService importService)
        {
            _importService = importService;
        }
    
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile archive)
        {
            var ms = new MemoryStream();
            await archive.CopyToAsync(ms);
            
            await _importService.ImportWordsAsync(ms);

            return Ok();
        }


        //[HttpPost]
        //[Route("upload")]
        //public async Task<IActionResult> Upload(IFormFile archive)
        //{
        //    var ms = new MemoryStream();
        //    await archive.CopyToAsync(ms);

        //    string str = Encoding.UTF8.GetString(ms.ToArray());

        //    var words = JsonSerializer.Deserialize<List<WordDto>>(str);

        //    //foreach (var word in words)
        //    //{
        //    //    await _wordRepository.CreateAsync(word);
        //    //}

        //    return Ok();
        //}
    }
}
