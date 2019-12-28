using System.Collections.Generic;
using System.Threading.Tasks;
using Dictionary.Services.Models.Word;
using Dictionary.Shared.Filters;

namespace Dictionary.Services.Services.Word
{
    public interface IWordService
    {
        Task CreateAsync(WordCreateServiceModel word);

        List<WordListServiceModel> List(WordFilterModel filter);
    }
}
