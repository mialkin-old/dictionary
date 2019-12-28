using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Database.Models;
using Dictionary.Database.Repositories.Word;
using Dictionary.Services.Models.Word;
using Dictionary.Shared.Filters.Word;

namespace Dictionary.Services.Services.Word
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;

        public WordService(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public async Task CreateAsync(WordCreateServiceModel word)
        {
            await _wordRepository.CreateAsync(new WordDto {
                Name = word.Name,
                Translation = word.Translation,
                Transcription = word.Transcription,
                GenderId = word.GenderId,
                LanguageId = word.LanguageId,
                Created = DateTime.Now
            });
        }

        public async Task<IList<WordListServiceModel>> ListAsync(WordListFilter filter)
        {
            var result = await _wordRepository.ListAsync(filter);

            return result
                .Select(x => new WordListServiceModel
                {
                    Id = x.WordId,
                    Name = x.Name,
                    GenderId = x.GenderId,
                    Translation = x.Translation,
                    Transcription = x.Transcription,
                    LanguageId = x.LanguageId
                })
                .ToList();
        }
    }
}
