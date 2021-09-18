using System;

namespace MovBooks.Core.DTOs
{
    public class RatingBookDto : BaseDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public double Rating { get; set; }
        public DateTime RatingDate { get; set; } = DateTime.Now;
        public string Comment { get; set; }
    }
}
