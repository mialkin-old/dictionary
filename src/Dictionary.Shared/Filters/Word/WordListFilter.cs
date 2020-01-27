namespace Dictionary.Shared.Filters.Word
{
    public class WordListFilter : ListFilter
    {
        public int? LanguageId { get; set; }

        public string SearchTerm { get; set; }
    }
}
