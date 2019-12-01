using System.Collections.Generic;
using Dictionary.Database;
using Dictionary.Database.Models;
using Dictionary.Services.Models.Word;


namespace Dictionary.Services
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;

        public WordService(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }
        public void Create(WordCreate word)
        {
            _wordRepository.Create(new Word { Name = word.Name });
        }
        public List<WordList> List(int languageId)
        {
            return _wordRepository.List(languageId).ConvertAll(x => new WordList { Id = x.WordId, Name = x.Name });
        }
    }
}
