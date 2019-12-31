using System.Linq;
using Dictionary.Database.Models;
using Dictionary.Shared.ExtensionMethods;
using Dictionary.Shared.Filters;
using Dictionary.Shared.Filters.Word;

namespace Dictionary.Database.ExtensionMethods
{
    public static class FiltersExtensionMethods
    {
        public static IQueryable<T> ApplyListFilter<T>(this IQueryable<T> query, ListFilter filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.OrderByPropertyName))
            {
                query = filter.OrderByDescending ?
                    query.OrderByPropertyNameDescending(filter.OrderByPropertyName) :
                    query.OrderByPropertyName(filter.OrderByPropertyName);
            }

            return query.Take(filter.Take);
        }

        public static IQueryable<WordDto> ApplyWordListFilter(this IQueryable<WordDto> query, WordListFilter filter)
        {
            return query
                .Where(x => x.LanguageId == filter.LanguageId)
                .ApplyListFilter(filter);
        }
    }
}
