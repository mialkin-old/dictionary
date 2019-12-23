using System.Collections.Generic;
using Dictionary.Services.Models.Word;

namespace Dictionary.Services
{
    public interface IWordService
    {
        void Create(WordCreateServiceModel word);

        public List<WordListServiceModel> List(int languageId);
    }
}
