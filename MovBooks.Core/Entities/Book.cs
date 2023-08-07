using System.Collections.Generic;

namespace MovBooks.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book()
        {
            RatingsBooks = new HashSet<RatingBook>();
            GenreBooks = new HashSet<GenreBooks>();
            ViewsBooks = new HashSet<ViewsBooks>();
        }

        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<GenreBooks> GenreBooks { get; set; }
        public virtual ICollection<RatingBook> RatingsBooks { get; set; }
        public virtual ICollection<ViewsBooks> ViewsBooks { get; set; }
    }
}
