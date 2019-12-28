using System.Collections.Generic;
using Dictionary.WebApi.ViewModels.Word;

namespace Dictionary.WebApi.ViewModels.Home
{
    public class HomeIndexViewModel
    {
        public List<WordListViewModel> Words { get; set; }
    }
}
