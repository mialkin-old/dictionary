using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Dictionary.Database.Models;
using Dictionary.Database.Repositories.Word;
using Dictionary.Services.Models.Word;
using Dictionary.Shared.Filters;
using FluentValidation;

namespace Dictionary.Services.Services.Word
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;
        private readonly IMapper _mapper;
        private readonly WordExistsValidator _wordExistsValidator;

        public WordService(IWordRepository wordRepository, IMapper mapper, WordExistsValidator wordExistsValidator)
        {
            _wordRepository = wordRepository;
            _mapper = mapper;
            _wordExistsValidator = wordExistsValidator;
        }

        public async Task<int> CreateAsync(WordCreateServiceModel model)
        {
            WordDto word = _mapper.Map<WordDto>(model);
            word.Created = DateTime.Now;

            _wordRepository.Add(word);
            await _wordRepository.SaveChangesAsync();

            return word.WordId;
        }

        public async Task UpdateAsync(WordUpdateServiceModel model)
        {
            WordDto word = _mapper.Map<WordDto>(model);

            await _wordRepository.UpdateAsync(word);
            await _wordRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            WordDto wordDto = _wordRepository.First(x => x.WordId == id);
            _wordRepository.Remove(wordDto);

            await _wordRepository.SaveChangesAsync();
        }

        public async Task<bool> WordExists(WordExistsServiceModel model)
        {
            await _wordExistsValidator.ValidateAndThrowAsync(model);
            
            
            WordDto word = await _wordRepository.GetByNameAsync(model.Name, model.LanguageId);

            return word != null;
        }

        public async Task<IList<WordListServiceModel>> ListAsync(WordListFilter filter)
        {
            IList<WordDto> result = await _wordRepository.ListAsync(filter);

            return _mapper.Map<IList<WordListServiceModel>>(result);
        }

        public async Task<IList<WordListServiceModel>> SearchAsync(WordSearchFilter filter)
        {
            IList<WordDto> result = await _wordRepository.SearchAsync(filter);

            return _mapper.Map<IList<WordListServiceModel>>(result);
        }
    }
}