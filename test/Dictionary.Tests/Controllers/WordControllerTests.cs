using System.Threading.Tasks;
using AutoMapper;
using Dictionary.Services.Services.Word;
using Dictionary.WebUi.Controllers;
using Dictionary.WebUi.ViewModels.Word;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Dictionary.Tests.Controllers
{
    [TestFixture]
    public class WordControllerTests
    {
        [Test]
        public void CreateWordIsNull()
        {
            var wordService = new Mock<IWordService>();
            var mapper = new Mock<IMapper>();
            var controller = new WordController(wordService.Object, mapper.Object);
            
            var wordCreateModel= new WordCreateVm();
            
            Task<IActionResult> task = controller.Create(wordCreateModel);
        }
    }
}