using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Dictionary.Services.Models.Export;
using Dictionary.Services.Models.Word;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.WebApi.Controllers
{
    [Route("import")]
    public class ImportController : Controller
    {
        public ImportController()
        {
            
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

            var words = JsonSerializer.Deserialize<List<WordExportServiceModel>>(str);

            return Ok();
        }
    }
}
