using System.Collections.Generic;

namespace MovBooks.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book()
        {
            RatingsBooks = new HashSet<RatingBook>();
            GenderBooks = new HashSet<GenderBooks>();
            ViewsBooks = new HashSet<ViewsBooks>();
        }

        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<GenderBooks> GenderBooks { get; set; }
        public virtual ICollection<RatingBook> RatingsBooks { get; set; }
        public virtual ICollection<ViewsBooks> ViewsBooks { get; set; }
    }
}
