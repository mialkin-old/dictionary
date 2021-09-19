namespace Dictionary.Shared.Filters
{
    public class WordListFilter
    {
        public int Take { get; set; } = 100;

        public int? L { get; set; }

        /// <summary>
        /// Name of the property to sort by.
        /// </summary>
        public string? OrderByPropertyName { get; set; }

        /// <summary>
        /// Sorting direction.
        /// </summary>
        public bool OrderByDescending { get; set; }
    }
}
