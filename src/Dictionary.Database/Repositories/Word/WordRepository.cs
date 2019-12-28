using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Database.Models;
using Dictionary.Shared.ExtensionMethods;
using Dictionary.Shared.Filters.Word;
using Microsoft.EntityFrameworkCore;

namespace Dictionary.Database.Repositories.Word
{
    public class WordRepository : IWordRepository
    {
        public WordRepository(DictionaryDb db)
        {
            Db = db;
        }
        public DictionaryDb Db { get; }

        public async Task CreateAsync(WordDto word)
        {
            Db.Add(word);
            await Db.SaveChangesAsync();
        }

        public async Task<IList<WordDto>> ListAsync(WordListFilter filter)
        {
            IQueryable<WordDto> query = Db.Words
                .Where(x => x.LanguageId == filter.LanguageId)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.OrderByPropertyName))
            {
                query = filter.OrderByDescending ?
                    query.OrderByPropertyNameDescending(filter.OrderByPropertyName) :
                    query.OrderByPropertyName(filter.OrderByPropertyName);
            }

            var result = await query
                .Take(filter.Take)
                .ToListAsync();

            return result;
        }
    }
}
