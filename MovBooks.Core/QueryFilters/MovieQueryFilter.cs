namespace MovBooks.Core.QueryFilters
{
    public class MovieQueryFilter : BaseQueryFilter
    {
        public bool? Aggregated { get; set; }
        public string Title { get; set; }
    }
}
