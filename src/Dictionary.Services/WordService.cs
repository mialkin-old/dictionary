using System.Collections.Generic;
using Dictionary.Database;
using Dictionary.Database.Models;
using Dictionary.Services.Models.Word;


namespace Dictionary.Services
{
    public class WordService : IWordService
    {
        IWordRepository repository;
        public WordService()
        {
            repository = new WordRepository();
        }
        public void Create(WordCreate word)
        {
            repository.Create(new Word { Name = word.Name });
        }

        public List<WordList> List(int languageId)
        {
            return repository.List(languageId).ConvertAll(x => new WordList { Id = x.WordId, Name = x.Name });
        }
    }
}
