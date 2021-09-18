using System.Collections.Generic;

namespace MovBooks.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book()
        {
            RatingsBooks = new HashSet<RatingBook>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public bool Aggregated { get; set; }

        public virtual ICollection<RatingBook> RatingsBooks { get; set; }
    }
}
