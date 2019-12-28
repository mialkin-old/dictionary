namespace Dictionary.Shared.Filters
{
    public class ListFilter
    {
        public int Take { get; set; } = 100;

        public string OrderByPropertyName { get; set; }

        public bool OrderByDescending { get; set; }
    }
}
