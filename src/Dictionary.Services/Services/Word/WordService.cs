using System.Collections.Generic;
using Dictionary.Database.Models;
using Dictionary.Database.Repositories.Word;
using Dictionary.Services.Models.Word;
using Dictionary.Shared.Filters;

namespace Dictionary.Services.Services.Word
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;

        public WordService(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }
        public void Create(WordCreateServiceModel word)
        {
            _wordRepository.Create(new WordDbModel { Name = word.Name });
        }

        public List<WordListServiceModel> List(WordFilterModel filter)
        {
            throw new System.NotImplementedException();
        }

        public List<WordListServiceModel> List(int languageId)
        {
            return _wordRepository
                .List(languageId)
                .ConvertAll(x => new WordListServiceModel { Id = x.WordId, Name = x.Name });
        }
    }
}
