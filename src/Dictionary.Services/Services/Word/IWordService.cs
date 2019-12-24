using System.Collections.Generic;
using Dictionary.Services.Models.Word;
using Dictionary.Shared.Filters;

namespace Dictionary.Services.Services.Word
{
    public interface IWordService
    {
        void Create(WordCreateServiceModel word);

        List<WordListServiceModel> List(WordFilterModel filter);
    }
}
