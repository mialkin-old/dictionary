using System.Collections.Generic;
using Dictionary.Database.Models;
using Dictionary.Database.Repositories.Word;
using Dictionary.Services.Models.Word;
using Dictionary.Services.ServiceValiators.Word;
using Dictionary.Shared.Filters;

namespace Dictionary.Services.Services.Word
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;
        private readonly IWordServiceValidator _wordServiceValidator;

        public WordService(IWordRepository wordRepository, IWordServiceValidator wordServiceValidator)
        {
            _wordRepository = wordRepository;
            _wordServiceValidator = wordServiceValidator;
        }
        public void Create(WordCreateServiceModel word)
        {
            _wordRepository.Create(new WordDbModel { Name = word.Name });
        }

        public List<WordListServiceModel> List(WordFilterModel filter)
        {
            _wordServiceValidator.ValidateWordFilterModel(filter);

            var result = _wordRepository.List(filter.LanguageId);

            return null;
        }

        public List<WordListServiceModel> List(int languageId)
        {
            return _wordRepository
                .List(languageId)
                .ConvertAll(x => new WordListServiceModel { Id = x.WordId, Name = x.Name });
        }
    }
}
