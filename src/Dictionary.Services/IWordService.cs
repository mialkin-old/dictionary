using Dictionary.Services.Models.Word;
using System.Collections.Generic;

namespace Dictionary.Services
{
    public interface IWordService
    {
        void Create(WordCreate word);

        public List<WordList> List(int languageId);
    }
}
