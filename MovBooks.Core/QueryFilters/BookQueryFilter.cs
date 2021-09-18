namespace MovBooks.Core.QueryFilters
{
    public class BookQueryFilter : BaseQueryFilter
    {
        public bool? Aggregated { get; set; }
        public string Title { get; set; }
    }
}
