using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dictionary.Database.Models;
using Dictionary.Database.Repositories.Word;
using Dictionary.Services.Models.Export;
using Dictionary.Services.Models.Word;
using Dictionary.Shared.Filters.Word;

namespace Dictionary.Services.Services.Word
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;
        private readonly IMapper _mapper;

        public WordService(IWordRepository wordRepository, IMapper mapper)
        {
            _wordRepository = wordRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(WordCreateServiceModel word)
        {
            WordDto model = _mapper.Map<WordDto>(word);
            model.Created = DateTime.Now;

            await _wordRepository.CreateAsync(model);
        }

        public Task ImportAsync(IList<WordExportServiceModel> words)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<WordListServiceModel>> ListAsync(WordListFilter filter)
        {
            IList<WordDto> result = await _wordRepository.ListAsync(filter);

            return _mapper.Map<IList<WordListServiceModel>>(result);
        }
    }
}
