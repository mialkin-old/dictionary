using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Database.Models;
using Dictionary.Shared.ExtensionMethods;
using Dictionary.Shared.Filters;
using Microsoft.EntityFrameworkCore;

namespace Dictionary.Database.Repositories.Word
{
    public class WordRepository : BaseRepository<WordDto>, IWordRepository
    {
        public WordRepository(DictionaryDb db) : base(db)
        {
        }

        public async Task CreateAsync(IEnumerable<WordDto> words)
        {
            // Грузить порциями по 1000 слов.
            await Entities.AddRangeAsync(words);
        }

        public async Task UpdateAsync(WordDto word)
        {
            var entity = await Entities.FindAsync(word.WordId);

            if (entity != null)
            {
                entity.GenderId = word.GenderId;
                entity.Transcription = word.Transcription;
                entity.Translation = word.Translation;

                Entities.Update(entity);
            }
        }

        public async Task<WordDto> GetByNameAsync(string name, int languageId)
        {
            var word = await Entities
                .Where(x => x.LanguageId == languageId && string.Equals(x.Name, name))
                .FirstOrDefaultAsync();

            return word;
        }

        public async Task<IList<WordDto>> ListAsync(WordListFilter filter)
        {
            var query = Entities.AsQueryable();

            if (filter.L != null)
            {
                query = query.Where(x => x.LanguageId == filter.L);
            }

            if (!string.IsNullOrWhiteSpace(filter.OrderByPropertyName))
            {
                query = filter.OrderByDescending ?
                    query.OrderByPropertyNameDescending(filter.OrderByPropertyName) :
                    query.OrderByPropertyName(filter.OrderByPropertyName);
            }

            var result = await query.Take(filter.Take).ToListAsync();
            return result;
        }

        public async Task<IList<WordDto>> SearchAsync(WordSearchFilter filter)
        {
            var query = Entities.AsQueryable();

            if (filter.L != null)
            {
                query = query.Where(x => x.LanguageId == filter.L);
            }

            if (!string.IsNullOrWhiteSpace(filter.Q))
            {
                query = query.Where(x => x.Name.StartsWith(filter.Q));
            }

            query = query
                .OrderBy(x => x.Name.Length)
                .ThenBy(x => x.Name);

            var result = await query.Take(filter.Take).ToListAsync();

            return result;
        }
    }
}
