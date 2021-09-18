namespace MovBooks.Core.DTOs
{
    public class BookDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Aggregated { get; set; }
    }
}
