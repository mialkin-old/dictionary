namespace Dictionary.Shared.Filters
{
    public class WordFilterModel
    {
        public int? LanguageId { get; set; }

        public int MaxWords { get; set; } = 100;
    }
}
