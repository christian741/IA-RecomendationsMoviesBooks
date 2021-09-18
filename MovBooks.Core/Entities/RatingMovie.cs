using System;

namespace MovBooks.Core.Entities
{
    public class RatingMovie : BaseEntity
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public double Rating { get; set; }
        public DateTime RatingDate { get; set; } = DateTime.Now;
        public string Comment { get; set; }

        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
