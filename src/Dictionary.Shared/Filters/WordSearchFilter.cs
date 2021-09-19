namespace Dictionary.Shared.Filters
{
    /// <summary>
    /// Word search filter.
    /// </summary>
    public class WordSearchFilter
    {
        /// <summary>
        /// How many words to take at once.
        /// </summary>
        public int Take { get; set; } = 100;

        /// <summary>
        /// Language ID.
        /// </summary>
        public int? L { get; set; }

        /// <summary>
        /// Query.
        /// </summary>
        public string Q { get; set; }

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
